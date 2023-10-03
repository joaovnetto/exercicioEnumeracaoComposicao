using Pedidos.Entities.Enums;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItems> Items { get; set; } = new List<OrderItems>();
        

        public Order() { }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItems items)
        {
            Items.Add(items);
        }
        public void RemoveItem(OrderItems items)
        {
            Items.Remove(items);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach (OrderItems items in Items)
            {
                sum += items.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItems item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
