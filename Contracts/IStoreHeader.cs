using DataModels.Entity;
using DataModels.ExtendedModels;

namespace Contracts
{
    public interface IStoreHeader
    {
        public int CreateStoreHeader(StoreHeader storeHeader);
        public IEnumerable<StoreHeader> GetAllStoreHeaders();
        public StoreHeader GetStoreHeaderById(int id);
        StoreExtended GetStoreHeaderWithDetails(int storeHeaderId);
    }
}
