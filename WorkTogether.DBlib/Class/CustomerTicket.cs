using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class CustomerTicket
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Done { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
