using System.ComponentModel.DataAnnotations;

namespace DataModels.Entity
{
    public class MaterialHeader
    {
        [Key]
        public int employeeId { get; set; }
        public string? storeNumber { get; set; }
        public string? shelfNumber { get; set; }
        public string? attachments { get; set; }
        //public virtual Employee Employee { get; set; }
    }
}
