using Oracle.ManagedDataAccess.Client;
using DA_BMCSDL.Models;
using System.Collections.Generic;

namespace DA_BMCSDL.Data
{
    public class ManagerRepository
    {
        private readonly string _user;
        private readonly string _pass;
        private readonly int _deptId;

        public ManagerRepository(string user, string pass, int deptId)
        {
            _user = user;
            _pass = pass;
            _deptId = deptId;
        }

        public List<EmployeeFullDto> GetMyDepartmentEmployees()
        {
            var list = new List<EmployeeFullDto>();

            using var conn = OracleHelper.GetConnection(_user, _pass);
            conn.Open();
            string sql = @"SELECT EMPLOYEEID, FULLNAME, BIRTHDATE, EMAIL,
                                  DEPARTMENTID, DEPARTMENTNAME,
                                  SALARY, TAXCODE, POSITION
                           FROM HR_APP.V_EMP_FOR_MANAGER";

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
                    Salary = reader.GetDecimal(reader.GetOrdinal("SALARY")),
                    TaxCode = reader.GetString(reader.GetOrdinal("TAXCODE"))
                });
            }
            return list;
        }
    }
}