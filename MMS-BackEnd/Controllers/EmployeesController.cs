using Contracts;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MMS_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeesController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]

        public int Create(Employee employee)
        {

            return _employeeService.Create(employee);

        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetAll();
        }
    }
}