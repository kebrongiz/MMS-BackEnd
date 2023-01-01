using Contracts;
using DataModels;
using DataModels.Entity;
using DataModels.ExtendedModels;

namespace Infrastructure
{
    public class EmployeeRepository : IEmployee
    {
        private readonly InventoryDbContext _dbContext;
        public EmployeeRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee.id;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }
        public IEnumerable<Employee> Search(string fpnumber, string? name)
        {
            IQueryable<Employee> query = _dbContext.Employees;

            if (fpnumber != null)
            {
                fpnumber = fpnumber.Trim();
                query = query.Where(e => e.fpNumber == fpnumber);
            }
            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim();
                query = query.Where(e => e.firstName.Contains(name) || e.middleName.Contains(name));
            }
            return query.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public EmployeeExtended GetEmployeeWithDetails(int employeeId)
        {
            return new EmployeeExtended(GetEmployeeById(employeeId))
            {
                MaterialItems = _dbContext.MaterialItems
                   .Where(a => a.employeeId == employeeId)
            };
        }
    }
}

