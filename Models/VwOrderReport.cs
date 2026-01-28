using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class VwOrderReport
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EventTitle { get; set; } = null!;

    public string SeatNumber { get; set; } = null!;

    public decimal PriceAtPurchase { get; set; }
}
