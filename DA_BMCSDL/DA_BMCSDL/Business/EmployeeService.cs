using DA_BMCSDL.Data;
using DA_BMCSDL.Models;
using System;
using System.Collections.Generic;

namespace DA_BMCSDL.Business
{
    public class EmployeeService
    {
        private readonly string _user;
        private readonly string _pass;
        private readonly string _role;
        private readonly int _deptId;

        public EmployeeService(string user, string pass, string role, int deptId)
        {
            _user = user;
            _pass = pass;
            _role = role;
            _deptId = deptId;
        }

        // ── Trưởng phòng ──────────────────────────────
        public List<EmployeeFullDto> GetManagerView()
        {
            if (_role != "MANAGER")
                throw new UnauthorizedAccessException("Bạn không có quyền Trưởng phòng!");

            var repo = new ManagerRepository(_user, _pass, _deptId);
            return repo.GetMyDepartmentEmployees();
        }

        // ── Kế toán ───────────────────────────────────
        public List<EmployeeFullDto> GetAccountingColleagues()
        {
            if (_role != "ACCOUNTING")
                throw new UnauthorizedAccessException("Bạn không có quyền Kế toán!");

            var repo = new AccountingRepository(_user, _pass);
            return repo.GetSameDeptEmployees(_deptId);
        }

        public List<SalaryDto> GetSalaryReport()
        {
            if (_role != "ACCOUNTING")
                throw new UnauthorizedAccessException("Bạn không có quyền Kế toán!");

            var repo = new AccountingRepository(_user, _pass);
            return repo.GetAllSalaryInfo();
        }
    }
}