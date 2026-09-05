namespace Company.DTOS
{
    public class EmployeeSaveDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
