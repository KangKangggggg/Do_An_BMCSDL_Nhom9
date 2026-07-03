using Oracle.ManagedDataAccess.Client;
using DA_BMCSDL.Models;
using System.Collections.Generic;

namespace DA_BMCSDL.Data
{
    public class AccountingRepository
    {
        private readonly string _user;
        private readonly string _pass;

        public AccountingRepository(string user, string pass)
        {
            _user = user;
            _pass = pass;
        }

        // Tab 1: xem đồng nghiệp cùng phòng — ẩn lương
        public List<EmployeeFullDto> GetSameDeptEmployees(int deptId)
        {
            var list = new List<EmployeeFullDto>();

            using var conn = OracleHelper.GetConnection(_user, _pass);
            conn.Open();
            string sql = @"SELECT EMPLOYEEID, FULLNAME, BIRTHDATE, EMAIL,
                                  DEPARTMENTID, DEPARTMENTNAME
                           FROM HR_APP.V_EMP_FOR_ACCOUNTING";

            using var cmd = new OracleCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new EmployeeFullDto
                {
                    EmpId = reader.GetInt32(reader.GetOrdinal("EMPLOYEEID")),
                    Name = reader.GetString(reader.GetOrdinal("FULLNAME")),
                    BirthDate = reader.GetDateTime(reader.GetOrdinal("BIRTHDATE"))
                                      .ToString("dd/MM/yyyy"),
                    Email = reader.GetString(reader.GetOrdinal("EMAIL")),
                    DeptId = reader.GetInt32(reader.GetOrdinal("DEPARTMENTID")),
                    DeptName = reader.GetString(reader.GetOrdinal("DEPARTMENTNAME")),
                    Salary = 0,
                    TaxCode = ""
                });
            }
            return list;
        }

        // Tab 2: xem bảng lương toàn công ty — chỉ 3 cột
        public List<SalaryDto> GetAllSalaryInfo()
        {
            var list = new List<SalaryDto>();

            using var conn = OracleHelper.GetConnection(_user, _pass);
            conn.Open();

            string sql = @"SELECT EMPLOYEEID, SALARY, TAXCODE
                           FROM HR_APP.V_SALARY_FOR_ACCOUNTING";

            using var cmd = new OracleCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SalaryDto
                {
                    EmpId = reader.GetInt32(reader.GetOrdinal("EMPLOYEEID")),
                    Salary = reader.GetDecimal(reader.GetOrdinal("SALARY")),
                    TaxCode = reader.GetString(reader.GetOrdinal("TAXCODE"))
                });
            }
            return list;
        }
    }
}