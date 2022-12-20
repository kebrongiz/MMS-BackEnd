using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entity
{
    public class MaterialItem
    {
        [Column("materilItemId")]
        public int id { get; set; }
        public string? type { get; set; }
        public string? model { get; set; }
        public string? serial { get; set; }
        public int? quantity { get; set; }
        public int? unitPrice { get; set; }
        public int? totalPrice { get; set; }
        [ForeignKey(nameof(Employee))]
        public int employeeId { get; set; }
    }
}
