using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entity
{
    public class TransferFrom
    {
        [Column("transferFromId")]
        public int id { get; set; }
        public string fpNumber { get; set; }
        public string rank { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
        public DateTimeOffset date { get; set; }
        public virtual ICollection<MaterialItem> MaterialItems { get; set; }

    }
}
