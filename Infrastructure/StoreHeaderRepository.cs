using Contracts;
using DataModels;
using DataModels.Entity;
using DataModels.ExtendedModels;

namespace Infrastructure
{
    public class StoreHeaderRepository : IStoreHeader
    {
        private readonly InventoryDbContext _dbContext;
        public StoreHeaderRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateStoreHeader(StoreHeader storeHeader)
        {
            _dbContext.StoreHeaders.Add(storeHeader);
            _dbContext.SaveChanges();
            return storeHeader.id;
        }

        public IEnumerable<StoreHeader> GetAllStoreHeaders()
        {
            return _dbContext.StoreHeaders.ToList();
        }

        public StoreHeader GetStoreHeaderById(int id)
        {
            return _dbContext.StoreHeaders.Find(id);
        }

        public StoreExtended GetStoreHeaderWithDetails(int storeHeaderId)
        {
            return new StoreExtended(GetStoreHeaderById(storeHeaderId))
            {
                MaterialItems = _dbContext.MaterialItems
                  .Where(a => a.storeHeaderId == storeHeaderId)
            };
        }
    }
}
