using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeesController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]

        public IActionResult CreateEmployee([FromBody] Employee employee)
        {

            try
            {
                if (employee == null)
                {

                    return BadRequest("employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _employeeService.CreateEmployee(employee);

                return CreatedAtRoute("EmployeeById", new { id = employee.id }, employee);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }
        [HttpGet("{search}")]
        public ActionResult<IEnumerable<Employee>> Search(string fpnumber, string? name)
        {
            try
            {
                var result = _employeeService.Search(fpnumber, name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id:int}", Name = "employeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }
        [HttpGet("{id}/materialItems")]
        public IActionResult GetEmployeeWithDetails(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeWithDetails(id);

                if (employee == null)
                {

                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}