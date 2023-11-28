using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Pack
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int NumberSlot { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
