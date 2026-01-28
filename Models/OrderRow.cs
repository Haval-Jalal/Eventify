using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class OrderRow
{
    public int OrderRowId { get; set; }

    public int OrderId { get; set; }

    public int TicketId { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
