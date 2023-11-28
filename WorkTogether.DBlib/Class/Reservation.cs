using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Reservation
{
    public int Id { get; set; }

    public int PackId { get; set; }

    public int TypeReservationId { get; set; }

    public int ClientId { get; set; }

    public string Code { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Price { get; set; }

    public int Percentage { get; set; }

    public virtual Customer Client { get; set; } = null!;

    public virtual Pack Pack { get; set; } = null!;

    public virtual TypeReservation TypeReservation { get; set; } = null!;

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
