using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class TypeReservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Percentage { get; set; }

    public int Month { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
