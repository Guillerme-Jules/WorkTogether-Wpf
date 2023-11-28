using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Unit
{
    public int Id { get; set; }

    public int? ReservationId { get; set; }

    public int RackId { get; set; }

    public int? TypeUnitId { get; set; }

    public int LocationSlot { get; set; }

    public virtual Rack Rack { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }

    public virtual TypeUnit? TypeUnit { get; set; }
}
