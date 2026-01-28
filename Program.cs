using Eventify.Models;
namespace Eventify

{
    internal class Program
    {
        static void Main(string[] args)
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
                        ListCustomers();
                        break;
                    case "2":
                        ListEvents();
                        break;
                    case "3":
                        CreateOrder();
                        break;
                    case "4":
                        BuyTicket();
                        break;
                    case "5":
                        UpdateOrderStatus();
                        break;
                    case "6":
                        DeleteOrder();
                        break;
                    case "7":
                        ShowReports();
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

            static void ListCustomers() { }
            static void ListEvents() { }
            static void CreateOrder() { }
            static void BuyTicket() { }
            static void UpdateOrderStatus() { }
            static void DeleteOrder() { }
            static void ShowReports() { }
        }
    }
}
