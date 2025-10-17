namespace eee.Models
{
    public class BulkItem : Item
    {
        public int BulkQuantity { get; set; }

        public BulkItem(string name, double price, int bulkQuantity)
            : base(name, price)
        {
            BulkQuantity = bulkQuantity;
        }
    }
}