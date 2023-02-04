using DataModels.Entity;

namespace DataModels.ExtendedModels
{
    public class StoreExtended
    {
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
        public IEnumerable<MaterialItem> MaterialItems { get; set; }
        public StoreExtended()
        {

        }
        public StoreExtended(StoreHeader storeHeader)
        {
            id = storeHeader.id;
            companyName = storeHeader.companyName;
            receiptNumber = storeHeader.receiptNumber;
            delivererId = storeHeader.delivererId;
            delivererTitle = storeHeader.delivererTitle;
            delivererFirstName = storeHeader.delivererFirstName;
            delivererFirstName = storeHeader.delivererFirstName;
            delivererLastName = storeHeader.delivererLastName;
            receiverFp = storeHeader.receiverFp;
            receiverTitle = storeHeader.receiverTitle;
            receiverFirstName = storeHeader.receiverFirstName;
            receiverMiddleName = storeHeader.receiverMiddleName;
            receiverLastName = storeHeader.receiverLastName;
            date = storeHeader.date;


        }
    }

}
