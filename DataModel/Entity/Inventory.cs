using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
  public class Inventory
    {
        [Column("inventoryId")]
        public int id { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string serial { get; set; }
        public double quantity { get; set; }
        public float unitPrice { get; set; }
        public float totalPrice { get; set; }
    }
}
