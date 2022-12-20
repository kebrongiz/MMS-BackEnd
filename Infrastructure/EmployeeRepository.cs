using Contracts;
using DataModels;
using DataModels.Entity;

namespace Infrastructure
{
    public class EmployeeRepository : IEmployee
    {
        private readonly InventoryDbContext _dbContext;
        public EmployeeRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee.id;
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }
    }
}

