using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Rack
{
    public int Id { get; set; }

    public int NumberSlot { get; set; }

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
