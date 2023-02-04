using DataModels.Entity;
using DataModels.ExtendedModels;

namespace Contracts
{
    public interface IEmployee
    {
        public int CreateEmployee(Employee employee);
        public IEnumerable<Employee> Search(string fpnumber, string? name);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        EmployeeExtended GetEmployeeWithDetails(int employeeId);
        public bool UpdateEmployee(int id, Employee employee);
        public bool DeleteEmployee(int id);
    }
}
