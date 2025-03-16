using Dapper_Service.Models;
using Dapper_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Service.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeeList();
            return Ok(employees);
        }

        [HttpGet("/getbycode")]
        public async Task<IActionResult> EmployeeModel(string employeeCode)
        {
            var employee = await _employeeService.GetEmployeeByCode(employeeCode);
            if (employee is null) return NotFound("Employee not found.");
            return Ok(employee);
        }

        [HttpPost("/search")]
        public async Task<IActionResult> SearchEmployee([FromBody] EmployeeSearchModel model)
        {
            var employee = await _employeeService.SearchEmployee(model);
            if (employee is null) return NotFound("Employee not found.");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeModel model)
        {
            if (model is null) return BadRequest("Invalid employee data.");

            var result = await _employeeService.CreateEmployee(model);
            if (result > 0) return Ok(new { Message = "Employee created successfully." });

            return StatusCode(500, "Error creating employee.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeModel model)
        {
            if (model is null) return BadRequest("Invalid employee data.");

            var result = await _employeeService.UpdateEmployee(model);
            if (result > 0) return Ok(new { Message = "Employee updated successfully." });

            return NotFound("Employee not found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (id <= 0) return BadRequest("Invalid employee ID.");

            var result = await _employeeService.Delete(id);
            if (result > 0) return Ok(new { Message = "Employee deleted successfully." });

            return NotFound("Employee not found.");
        }
    }
}
