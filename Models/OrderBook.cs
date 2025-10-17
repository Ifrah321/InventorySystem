using System.Collections.Generic;
using System.Linq;

namespace eee.Models
{
    public class OrderBook
    {
        public List<Order> QuedOrders { get; } = new();
        public List<Order> ProcessedOrders { get; } = new();

        public void QueOrder(Order order) => QuedOrders.Add(order);

        public void ProcessNextOrder()
        {
            if (QuedOrders.Count == 0) return;
            var next = QuedOrders.First();
            QuedOrders.RemoveAt(0);
            ProcessedOrders.Add(next);
        }

        public double TotalRevenue() => ProcessedOrders.Sum(o => o.TotalPrice());
    }
}