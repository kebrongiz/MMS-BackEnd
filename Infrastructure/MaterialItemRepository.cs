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
        public int CreateMaterialItemForImployee(int employeeeId, MaterialItem materialItem)
        {
            materialItem.employeeId = employeeeId;
            materialItem.totalPrice = materialItem.quantity * materialItem.unitPrice;

            _InventoryRepository.MaterialItems.Add(materialItem);
            _InventoryRepository.SaveChanges();
            return materialItem.id;
        }

        public IEnumerable<MaterialItem> GetAllMaterialItems()
        {
            var materialItems = _InventoryRepository.MaterialItems
                .GroupBy(x => x.model)
                .Select(m => new MaterialItem
                {
                    type = m.Select(x => x.type).FirstOrDefault(),
                    model = m.Key,
                    quantity = m.Sum(x => x.quantity),
                    serial = m.Select(m => m.serial).FirstOrDefault(),
                    unitPrice = m.Max(x => x.unitPrice),
                    totalPrice = m.Max(m => m.totalPrice)

                }).ToList();

            return materialItems;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _InventoryRepository.Employees.Find(employeeId);
        }

        public IEnumerable<MaterialItem> GetMaterialItemForEmployee(int empoyeeId, int id)
        {
            throw new NotImplementedException();
        }
    }
}

