using DataModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IInventory
    {
        public int Create(Inventory Inventory);
        public List<Inventory> GetAll();
    }
}
