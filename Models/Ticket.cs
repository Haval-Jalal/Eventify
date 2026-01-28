using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int EventId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
}
