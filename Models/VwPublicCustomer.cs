using System;
using System.Collections.Generic;

namespace Eventify.Models;

public partial class VwPublicCustomer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
