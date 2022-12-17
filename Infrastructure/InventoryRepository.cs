using DataModels.Entity;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Infrastructure
{
    public class InventoryRepository: IInventory
    {
        private readonly InventoryDbContext _InventoryRepository;
        public InventoryRepository(InventoryDbContext InventoryRepository)
        {
            _InventoryRepository = InventoryRepository;
        }
        public int Create(Inventory inventory)
        {
            _InventoryRepository.Inventories.Add(inventory);
            _InventoryRepository.SaveChanges();
            return inventory.id;
        }
        public List<Inventory> GetAll()
        {
            return _InventoryRepository.Inventories.ToList();
        }

    }
}

