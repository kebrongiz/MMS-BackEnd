using DataModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployee
    {
        public int Create(Employee employee);
        public List<Employee> GetAll();
    }
}
