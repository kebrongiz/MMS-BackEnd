using System.ComponentModel.DataAnnotations.Schema;


namespace DataModels.Entity
{
    public class Employee
    {
        [Column("employeId")]
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public  string gender { get; set; }
        public string department { get; set; }
        public DateTimeOffset date { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
