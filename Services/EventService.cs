using Eventify.Models;

namespace Eventify.Services
{
    public static class EventService
    {
        public static void ListEvents()
        {
            using var db = new EventifyContext();

            var events = db.Events
                           .Select(e => new
                           {
                               e.EventId,
                               e.Title,
                               e.EventDate,
                               Venue = e.Venue.Name,
                               e.Price
                           })
                           .ToList();

            Console.Clear();
            Console.WriteLine("==== EVENTS ====\n");

            if (!events.Any())
            {
                Console.WriteLine("No events found.");
            }
            else
            {
                foreach (var e in events)
                {
                    Console.WriteLine($"{e.EventId} | {e.Title} | {e.EventDate:d} | {e.Venue} | {e.Price} kr");
                }
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

