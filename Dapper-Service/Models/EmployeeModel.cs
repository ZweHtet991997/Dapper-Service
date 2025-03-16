namespace Dapper_Service.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficeLocation { get; set; }
        public string Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class EmployeeSearchModel
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}
