--  Tạo hàm chính sách VPD cho Trưởng phòng
CREATE OR REPLACE FUNCTION policy_manager(
    p_schema IN VARCHAR2,
    p_table  IN VARCHAR2
) RETURN VARCHAR2
AUTHID CURRENT_USER  
IS
    v_dept_id NUMBER;
BEGIN
    -- Lấy phòng ban của Trưởng phòng đang đăng nhập
    SELECT DEPARTMENTID INTO v_dept_id
    FROM HR_APP.EMPLOYEE
    WHERE ORACLEUSER = SYS_CONTEXT('USERENV', 'SESSION_USER');

    -- Trả về điều kiện WHERE tự động gắn vào mọi câu query
    RETURN 'DEPARTMENTID = ' || v_dept_id;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Nếu không tìm thấy user → chặn toàn bộ
        RETURN '1=0';
END policy_manager;
/


--  Tạo hàm chính sách VPD cho Kế toán
CREATE OR REPLACE FUNCTION policy_accounting(
    p_schema IN VARCHAR2,
    p_table  IN VARCHAR2
) RETURN VARCHAR2
AUTHID CURRENT_USER
IS
    v_dept_id NUMBER;
BEGIN
   
    RETURN 'DEPARTMENTID = 3';
END policy_accounting;
/

--  Đăng ký VPD Policy lên bảng EMPLOYEE
-- Policy cho Trưởng phòng: chỉ áp dụng khi SELECT
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'HR_APP',
        object_name     => 'V_EMP_FOR_MANAGER',  
        policy_name     => 'POLICY_MANAGER',
        policy_function => 'POLICY_MANAGER',
        statement_types => 'SELECT',
        policy_type     => DBMS_RLS.DYNAMIC
    );
END;
/

-- Đăng ký VPD Policy cho Kế toán 
BEGIN
    SYS.DBMS_RLS.ADD_POLICY(
        object_schema   => 'HR_APP',
        object_name     => 'V_EMP_FOR_ACCOUNTING',
        policy_name     => 'POLICY_ACCOUNTING',
        policy_function => 'POLICY_ACCOUNTING',
        statement_types => 'SELECT',
        policy_type     => SYS.DBMS_RLS.DYNAMIC
    );
END;
/
--  Tạo View đơn giản (không lọc) để C# truy vấn
CREATE OR REPLACE VIEW V_EMP_FOR_MANAGER AS
SELECT e.EMPLOYEEID,
       e.FULLNAME,
       e.BIRTHDATE,
       e.EMAIL,
       e.DEPARTMENTID,
       d.DEPARTMENTNAME,
       e.SALARY,
       e.TAXCODE,
       e.POSITION
FROM EMPLOYEE e
JOIN DEPARTMENT d ON e.DEPARTMENTID = d.DEPARTMENTID;

-- View đơn giản cho Kế toán xem đồng nghiệp (ẩn lương)
CREATE OR REPLACE VIEW V_EMP_FOR_ACCOUNTING AS
SELECT e.EMPLOYEEID,
       e.FULLNAME,
       e.BIRTHDATE,
       e.EMAIL,
       e.DEPARTMENTID,
       e.TAXCODE,
       d.DEPARTMENTNAME
       -- Cột SALARY và TAXCODE bị loại khỏi View này
FROM EMPLOYEE e
JOIN DEPARTMENT d ON e.DEPARTMENTID = d.DEPARTMENTID;

-- View cho Kế toán xem bảng lương 
CREATE OR REPLACE VIEW V_SALARY_FOR_ACCOUNTING AS
SELECT EMPLOYEEID, SALARY, TAXCODE
FROM EMPLOYEE;

--  Tạo Roles và cấp quyền
CREATE ROLE ROLE_MANAGER;
CREATE ROLE ROLE_ACCOUNTING;

-- Trưởng phòng: SELECT qua View 
GRANT SELECT ON V_EMP_FOR_MANAGER TO ROLE_MANAGER;

-- Kế toán: SELECT qua 2 View riêng
GRANT SELECT ON V_EMP_FOR_ACCOUNTING  TO ROLE_ACCOUNTING;
GRANT SELECT ON V_SALARY_FOR_ACCOUNTING TO ROLE_ACCOUNTING;

-- Tạo Users và gán Role
CREATE USER tp_it     IDENTIFIED BY "Pass123";
CREATE USER ke_toan_a IDENTIFIED BY "Pass123";

GRANT CREATE SESSION TO tp_it, ke_toan_a;
GRANT ROLE_MANAGER    TO tp_it;
GRANT ROLE_ACCOUNTING TO ke_toan_a;

