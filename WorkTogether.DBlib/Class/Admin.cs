using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class Admin
{
    public int Id { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
