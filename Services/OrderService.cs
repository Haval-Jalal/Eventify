using Eventify.Models;

namespace Eventify.Services
{
    public static class OrderService
    {
        public static void CreateOrder()
        {
            using var db = new EventifyContext();

            Console.Clear();
            Console.WriteLine("==== CREATE ORDER ====\n");

            var customers = db.Customers.ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers exist.");
                Pause();
                return;
            }

            Console.WriteLine("Select Customer ID:\n");

            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CustomerId} | {c.FirstName} {c.LastName}");
            }

            Console.Write("\nCustomer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId) ||
                !customers.Any(c => c.CustomerId == customerId))
            {
                Console.WriteLine("Invalid customer ID.");
                Pause();
                return;
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Status = "Pending"
            };

            db.Orders.Add(order);
            db.SaveChanges();

            Console.WriteLine($"\nOrder created successfully! Order ID: {order.OrderId}");
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        public static void BuyTicket()
        {
            using var db = new EventifyContext();

            Console.Clear();
            Console.WriteLine("==== BUY TICKET ====\n");

            var orders = db.Orders.ToList();

            if (!orders.Any())
            {
                Console.WriteLine("No orders exist.");
                Pause();
                return;
            }

            Console.WriteLine("Select Order ID:\n");
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.OrderId} | Customer: {o.CustomerId} | Status: {o.Status}");
            }

            Console.Write("\nOrder ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId) ||
                !orders.Any(o => o.OrderId == orderId))
            {
                Console.WriteLine("Invalid Order ID.");
                Pause();
                return;
            }

            var events = db.Events.ToList();

            Console.Clear();
            Console.WriteLine("Select Event:\n");
            foreach (var e in events)
            {
                Console.WriteLine($"{e.EventId} | {e.Title} | {e.EventDate:d} | {e.Price} kr");
            }

            Console.Write("\nEvent ID: ");
            if (!int.TryParse(Console.ReadLine(), out int eventId) ||
                !events.Any(e => e.EventId == eventId))
            {
                Console.WriteLine("Invalid Event ID.");
                Pause();
                return;
            }

            Console.Write("Seat number: ");
            var seat = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(seat))
            {
                Console.WriteLine("Seat number required.");
                Pause();
                return;
            }

            var ticket = new Ticket
            {
                EventId = eventId,
                SeatNumber = seat
            };

            db.Tickets.Add(ticket);
            db.SaveChanges();

            var price = events.First(e => e.EventId == eventId).Price;

            var orderRow = new OrderRow
            {
                OrderId = orderId,
                TicketId = ticket.TicketId,
                PriceAtPurchase = price
            };

            db.OrderRows.Add(orderRow);
            db.SaveChanges();

            Console.WriteLine("\nTicket purchased successfully!");
            Pause();
        }

        public static void UpdateOrderStatus()
        {
            using var db = new EventifyContext();

            Console.Clear();
            Console.WriteLine("==== UPDATE ORDER STATUS ====\n");

            var orders = db.Orders.ToList();

            if (!orders.Any())
            {
                Console.WriteLine("No orders exist.");
                Pause();
                return;
            }

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.OrderId} | Customer: {o.CustomerId} | Status: {o.Status}");
            }

            Console.Write("\nOrder ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid input.");
                Pause();
                return;
            }

            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                Pause();
                return;
            }

            Console.WriteLine("\nNew Status:");
            Console.WriteLine("1. Pending");
            Console.WriteLine("2. Paid");
            Console.WriteLine("3. Cancelled");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();

            order.Status = choice switch
            {
                "1" => "Pending",
                "2" => "Paid",
                "3" => "Cancelled",
                _ => order.Status
            };

            db.SaveChanges();

            Console.WriteLine("\nOrder status updated.");
            Pause();
        }

        public static void DeleteOrder()
        {
            using var db = new EventifyContext();

            Console.Clear();
            Console.WriteLine("==== DELETE ORDER ====\n");

            var orders = db.Orders.ToList();

            if (!orders.Any())
            {
                Console.WriteLine("No orders exist.");
                Pause();
                return;
            }

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.OrderId} | Customer: {o.CustomerId} | Status: {o.Status}");
            }

            Console.Write("\nOrder ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid input.");
                Pause();
                return;
            }

            var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                Pause();
                return;
            }

            var rows = db.OrderRows.Where(r => r.OrderId == orderId).ToList();
            db.OrderRows.RemoveRange(rows);

            db.Orders.Remove(order);
            db.SaveChanges();

            Console.WriteLine("\nOrder deleted successfully.");
            Pause();
        }



    }
}
