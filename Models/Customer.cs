using System.Collections.Generic;

namespace eee.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<OrderLine> PurchaseHistory { get; set; } = new();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddPurchase(OrderLine line) => PurchaseHistory.Add(line);
    }
}