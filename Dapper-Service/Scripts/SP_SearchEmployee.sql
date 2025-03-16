CREATE PROCEDURE SearchEmployees
    @FullName NVARCHAR(50) = NULL,
    @Department NVARCHAR(50) = NULL,
    @Email NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        EmployeeCode,
        FullName,
        Email,
        PhoneNumber,
        OfficeLocation,
        Department,
        CreatedDate,
        UpdatedDate
    FROM 
        dbo.Tbl_Employee
    WHERE 
        (@FullName IS NULL OR FullName LIKE '%' + @FullName + '%')
        AND (@Department IS NULL OR Department LIKE '%' + @Department + '%')
        AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')
    ORDER BY FullName;
END;
GO
