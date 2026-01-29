using Eventify.Services;

namespace Eventify.Services
{
    public static class MenuService
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== EVENTIFY ====");
                Console.WriteLine("1. List Customers");
                Console.WriteLine("2. List Events");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("4. Buy Ticket");
                Console.WriteLine("5. Update Order Status");
                Console.WriteLine("6. Delete Order");
                Console.WriteLine("7. Reports");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CustomerService.ListCustomers();
                        break;
                    case "2":
                        EventService.ListEvents();
                        break;
                    case "3":
                        OrderService.CreateOrder();
                        break;
                    case "4":
                        OrderService.BuyTicket();
                        break;
                    case "5":
                        OrderService.UpdateOrderStatus();
                        break;
                    case "6":
                        OrderService.DeleteOrder();
                        break;
                    case "7":
                        ReportService.ShowReports();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Pause();
                        break;
                }
            }

            static void Pause()
            {
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
        }
    }
}
