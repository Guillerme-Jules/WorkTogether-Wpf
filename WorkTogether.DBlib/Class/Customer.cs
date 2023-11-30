using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Customer: User
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public virtual ICollection<CustomerTicket> CustomerTickets { get; set; } = new List<CustomerTicket>();
    
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
