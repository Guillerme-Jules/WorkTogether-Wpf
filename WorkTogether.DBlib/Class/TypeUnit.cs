using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class TypeUnit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
