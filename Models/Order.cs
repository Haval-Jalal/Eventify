using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
