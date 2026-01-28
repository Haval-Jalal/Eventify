using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
