using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;
using eee.Models;

namespace eee
{
    public partial class MainWindow : Window
    {
        private readonly OrderBook orderBook = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadSampleOrders();
            RefreshLists();
        }

        private void LoadSampleOrders()
        {
            var item1 = new Item("Vare 1", 200);
            var item2 = new Item("Vare 2", 250);
            var item3 = new Item("Vare 3", 500);
            var item4 = new Item("Vare 4", 420);
            var item5 = new Item("Vare 5", 390);
            
            var order1 = new Order();
            order1.OrderLines.Add(new OrderLine(item1, 1));
            order1.OrderLines.Add(new OrderLine(item2, 1));
            
            var order2 = new Order();
            order2.OrderLines.Add(new OrderLine(item3, 1));
            order2.OrderLines.Add(new OrderLine(item4, 1));
            
            var order3 = new Order();
            order3.OrderLines.Add(new OrderLine(item5, 1));
            order3.OrderLines.Add(new OrderLine(item2, 1));
            
            orderBook.QueOrder(order1);
            orderBook.QueOrder(order2);
            orderBook.QueOrder(order3);
        }


        private void RefreshLists()
        {
            QuedOrdersList.ItemsSource = null;
            ProcessedOrdersList.ItemsSource = null;

            QuedOrdersList.ItemsSource = orderBook.QuedOrders.Select(o => o.ToString()).ToList();
            ProcessedOrdersList.ItemsSource = orderBook.ProcessedOrders.Select(o => o.ToString()).ToList();

            RevenueText.Text = $"Total Revenue: {orderBook.TotalRevenue()} kr";
        }

        private void ProcessNext_Click(object? sender, RoutedEventArgs e)
        {
            orderBook.ProcessNextOrder();
            RefreshLists();
            OrderDetailsList.ItemsSource = null;
        }

        private void QuedOrdersList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = QuedOrdersList.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < orderBook.QuedOrders.Count)
            {
                var selectedOrder = orderBook.QuedOrders[selectedIndex];
                OrderDetailsList.ItemsSource = selectedOrder.OrderLines
                    .Select(l => $"{l.Item.Name} x{l.Quantity} = {l.LineTotal()} kr")
                    .ToList();
            }
        }
    }
}
