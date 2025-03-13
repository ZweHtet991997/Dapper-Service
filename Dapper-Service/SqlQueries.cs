namespace Dapper_Service
{
    public static class SqlQueries
    {
        public static string GetAllEmployees = "SELECT * FROM Tbl_Employee";

        public static string CreateEmployee = "INSERT INTO Tbl_Employee (EmployeeCode,FullName,Email,PhoneNumber,OfficeLocation,Department,CreatedDate) " +
                $"VALUES (@EmployeeCode,@FullName,@Email,@PhoneNumber,@OfficeLocation,@Department,@CreatedDate)";

        public static string UpdateEmployee = "UPDATE Tbl_Employee SET EmployeeCode=@EmployeeCode,FullName=@FullName,Email=@Email,PhoneNumber=@PhoneNumber," +
                "OfficeLocation=@OfficeLocation,Department=@Department WHERE ID=@Id";

        public static string DeleteEmployee = "DELETE FROM Tbl_Employee WHERE ID=@Id";
    }
}
