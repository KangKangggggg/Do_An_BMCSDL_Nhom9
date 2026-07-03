namespace DA_BMCSDL.Models
{
    public class EmployeeFullDto
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public decimal Salary { get; set; }
        public string TaxCode { get; set; }
    }
}