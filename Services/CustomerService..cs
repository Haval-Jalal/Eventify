using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Models;

namespace Eventify.Services
{
    public class CustomerService
    {
        public static void ListCustomers()
        {
            using var db = new EventifyContext();

            var customers = db.Customers.ToList();

            Console.Clear();
            Console.WriteLine("==== CUSTOMERS ====\n");

            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
            }
            else
            {
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.CustomerId} | {c.FirstName} {c.LastName} | {c.Email}");
                }
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
