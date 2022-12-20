using DataModels.Entity;

namespace Contracts
{
    public interface IMaterialHeader
    {
        public int Create(MaterialHeader materialHeader);
        public List<MaterialHeader> GetAll();
    }
}
