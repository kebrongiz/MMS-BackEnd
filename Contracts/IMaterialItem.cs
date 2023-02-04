using DataModels.Entity;

namespace Contracts
{
    public interface IMaterialItem
    {
        public int CreateMaterialItemForImployee(int employyeeId, MaterialItem materialItem);
        public IEnumerable<MaterialItem> GetAllMaterialItems();
        public Employee GetEmployeeById(int employeeId);
        public IEnumerable<MaterialItem> GetMaterialItemForEmployee(int empoyeeId, int id);
    }
}
