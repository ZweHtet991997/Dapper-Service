using Dapper;
using Dapper_Service.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data;

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
                //Querying multiple rows
                var dataResult = await connection.QueryAsync<EmployeeModel>(query);

                return dataResult.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeModel> GetEmployeeByCode(string employeeCode)
        {
            try
            {
                string query = SqlQueries.GetEmployeeByCode;

                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", employeeCode);
                await using var connection = _dbConnectionService.OpenConnection();
                //Querying single row
                var dataResult = await connection.QuerySingleAsync<EmployeeModel>(query,parameters);

                return dataResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<EmployeeModel>> SearchEmployee(EmployeeSearchModel model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FullName", model.FullName);
                parameters.Add("@Department", model.Department);
                parameters.Add("@Email", model.Email);

                await using var connection = _dbConnectionService.OpenConnection();
                //Executing store procedure
                var dataResult = await connection.QueryAsync<EmployeeModel>("SearchEmployees",
                    parameters, commandType: CommandType.StoredProcedure);

                return dataResult.ToList();
            }
            catch (Exception)
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
                //Inserting data
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
            //Updating data
            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> Delete(int id)
        {
            string query = SqlQueries.DeleteEmployee;

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            await using var connection = _dbConnectionService.OpenConnection();
            //Deleting data
            return await connection.ExecuteAsync(query, parameters);
        }
    }
}
