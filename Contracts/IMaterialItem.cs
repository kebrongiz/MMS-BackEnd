using DataModels.Entity;

namespace Contracts
{
    public interface IMaterialItem
    {
        public int Create(MaterialItem materialItem);
        public List<MaterialItem> GetAll();
    }
}
