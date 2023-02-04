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

        public bool UpdateEmployee(int id, Employee employee)
        {
            string Result = string.Empty;
            int processcount = 0;
            var existing = _dbContext.Employees.Find(id);
            if (existing != null)
            {
                existing.fpNumber = employee.fpNumber;
                existing.rank = employee.rank;
                existing.firstName = employee.firstName;
                existing.middleName = employee.middleName;
                existing.lastName = employee.lastName;
                existing.gender = employee.gender;
                existing.department = employee.department;
                existing.date = employee.date;
                if (employee.MaterialItems != null && employee.MaterialItems.Count > 0)
                {
                    foreach (var item in employee.MaterialItems)
                    {
                        var resp = UpdateEmployeeMaterialItem(item, employee.id);
                        if (resp.Result)
                        {
                            processcount++;
                        }
                    }
                    if (processcount == employee.MaterialItems.Count)
                    {
                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                _dbContext.Employees.Update(existing);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        private async Task<bool> UpdateEmployeeMaterialItem(MaterialItem material, int employeeId)
        {
            bool Result = false;

            try
            {
                var _existdata = _dbContext.MaterialItems.FirstOrDefault(item => item.id == material.id);
                if (_existdata != null)
                {

                    _existdata.type = material.type;
                    _existdata.model = material.model;
                    _existdata.serial = material.serial;
                    _existdata.quantity = material.quantity;
                    _existdata.unitPrice = material.unitPrice;
                    _existdata.totalPrice = material.totalPrice;
                    _existdata.employeeId = material.employeeId;

                }
                else
                {
                    var _newrecord = new MaterialItem()
                    {
                        type = material.type,
                        model = material.model,
                        serial = material.serial,
                        quantity = material.quantity,
                        unitPrice = material.unitPrice,
                        totalPrice = material.totalPrice,
                        employeeId = material.employeeId
                    };
                    _dbContext.MaterialItems.Add(_newrecord);
                }
                Result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool DeleteEmployee(int id)
        {
            var existing = _dbContext.Employees.Find(id);
            if (existing != null)
            {
                _dbContext.Employees.Remove(existing);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

