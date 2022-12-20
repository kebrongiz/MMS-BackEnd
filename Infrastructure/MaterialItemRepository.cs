using Contracts;
using DataModels;
using DataModels.Entity;

namespace Infrastructure
{
    public class MaterialItemRepository : IMaterialItem
    {
        private readonly InventoryDbContext _InventoryRepository;
        public MaterialItemRepository(InventoryDbContext InventoryRepository)
        {
            _InventoryRepository = InventoryRepository;
        }
        public int Create(MaterialItem materialItem)
        {
            _InventoryRepository.MaterialItems.Add(materialItem);
            _InventoryRepository.SaveChanges();
            return materialItem.id;
        }
        public List<MaterialItem> GetAll()
        {
            return _InventoryRepository.MaterialItems.ToList();
        }

    }
}

