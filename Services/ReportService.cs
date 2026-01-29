using Eventify.Models;

namespace Eventify.Services
{
    public static class ReportService
    {
        public static void ShowReports()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== REPORTS ====");
                Console.WriteLine("1. Top Customers");
                Console.WriteLine("2. Sales per Event");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TopCustomers();
                        break;

                    case "2":
                        SalesPerEvent();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // REPORT 1
        static void TopCustomers()
        {
            using var db = new EventifyContext();

            var report = db.Orders
                .GroupBy(o => new { o.Customer.FirstName, o.Customer.LastName })
                .Select(g => new
                {
                    Name = g.Key.FirstName + " " + g.Key.LastName,
                    TotalOrders = g.Count()
                })
                .OrderByDescending(x => x.TotalOrders)
                .ToList();

            Console.Clear();
            Console.WriteLine("==== TOP CUSTOMERS ====\n");

            foreach (var r in report)
            {
                Console.WriteLine($"{r.Name,-25} Orders: {r.TotalOrders}");
            }

            Pause();
        }

        // REPORT 2
        static void SalesPerEvent()
        {
            using var db = new EventifyContext();

            var report = db.OrderRows
                .GroupBy(r => r.Ticket.Event.Title)
                .Select(g => new
                {
                    Event = g.Key,
                    Revenue = g.Sum(x => x.PriceAtPurchase)
                })
                .OrderByDescending(x => x.Revenue)
                .ToList();

            Console.Clear();
            Console.WriteLine("==== SALES PER EVENT ====\n");

            foreach (var r in report)
            {
                Console.WriteLine($"{r.Event,-25} Revenue: {r.Revenue} kr");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
