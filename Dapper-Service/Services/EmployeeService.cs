using Dapper;
using Dapper_Service.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_Service.Services
{
    public class EmployeeService
    {
        private readonly DbConnectionService _dbConnectionService;

        public EmployeeService(DbConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        public async Task<List<EmployeeModel>> GetEmployeeList()
        {
            try
            {
                string query = SqlQueries.GetAllEmployees;

                await using var connection = _dbConnectionService.OpenConnection();
                var dataResult = await connection.QueryAsync<EmployeeModel>(query);

                return dataResult.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CreateEmployee(EmployeeModel model)
        {
            try
            {
                string query = SqlQueries.CreateEmployee;

                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", model.EmployeeCode);
                parameters.Add("@FullName", model.FullName);
                parameters.Add("@Email", model.Email);
                parameters.Add("@PhoneNumber", model.PhoneNumber);
                parameters.Add("@OfficeLocation", model.OfficeLocation);
                parameters.Add("@Department", model.Department);
                parameters.Add("@CreatedDate", DateTime.Now);

                await using var connection = _dbConnectionService.OpenConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateEmployee(EmployeeModel model)
        {
            string query = SqlQueries.UpdateEmployee;

            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@EmployeeCode", model.EmployeeCode);
            parameters.Add("@EmployeeCode", model.EmployeeCode);
            parameters.Add("@FullName", model.FullName);
            parameters.Add("@Email", model.Email);
            parameters.Add("@PhoneNumber", model.PhoneNumber);
            parameters.Add("@OfficeLocation", model.OfficeLocation);
            parameters.Add("@Department", model.Department);
            parameters.Add("@UpdatedDate", DateTime.Now);

            await using var connection = _dbConnectionService.OpenConnection();
            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> Delete(int id)
        {
            string query = SqlQueries.DeleteEmployee;

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            await using var connection = _dbConnectionService.OpenConnection();
            return await connection.ExecuteAsync(query, parameters);
        }
    }
}
