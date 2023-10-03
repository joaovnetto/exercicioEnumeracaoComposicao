using System;
using Pedidos.Entities;
using Pedidos.Entities.Enums;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            DateTime moment = DateTime.Now;

            Client client = new Client(name, email, birthDate);
            Order order = new Order(moment, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string item = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");

                int q = int.Parse(Console.ReadLine());

                Product product = new Product(item, price);

                OrderItems orderItem = new OrderItems(q, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine("ORDER SUMARY:");
            Console.WriteLine(order);
           
        }
    }
}