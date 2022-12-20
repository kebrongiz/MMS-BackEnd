using Contracts;
using DataModels;
using DataModels.Entity;

namespace Infrastructure
{
    public class MaterialHeaderRepository : IMaterialHeader
    {
        private readonly InventoryDbContext _dbContext;
        public MaterialHeaderRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(MaterialHeader materialHeader)
        {
            _dbContext.MaterialHeaders.Add(materialHeader);
            _dbContext.SaveChanges();
            return materialHeader.employeeId;
        }

        public List<MaterialHeader> GetAll()
        {
            return _dbContext.MaterialHeaders.ToList();
        }
    }
}
