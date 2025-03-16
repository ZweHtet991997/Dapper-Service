-- Search by FullName
EXEC usp_SearchEmployees @FullName = 'John';

-- Search by Department
EXEC usp_SearchEmployees @Department = 'IT';

-- Search by Email
EXEC usp_SearchEmployees @Email = 'john@example.com';

-- Search by multiple criteria
EXEC usp_SearchEmployees @FullName = 'John', @Department = 'HR';

-- Search without filters (returns all employees)
EXEC usp_SearchEmployees;
