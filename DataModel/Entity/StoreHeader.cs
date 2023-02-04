using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entity
{
    public class StoreHeader
    {
        [Column("storeHeaderId")]
        public int id { get; set; }
        public string companyName { get; set; }
        public string receiptNumber { get; set; }
        public string delivererId { get; set; }
        public string delivererTitle { get; set; }
        public string delivererFirstName { get; set; }
        public string delivererMiddleName { get; set; }
        public string delivererLastName { get; set; }
        public string receiverFp { get; set; }
        public string receiverTitle { get; set; }
        public string receiverFirstName { get; set; }
        public string receiverMiddleName { get; set; }
        public string receiverLastName { get; set; }
        public DateTimeOffset date { get; set; }
        public virtual ICollection<MaterialItem> MaterialItems { get; set; }
    }
}
