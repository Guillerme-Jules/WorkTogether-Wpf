using System;
using System.Collections.Generic;

namespace WorkTogether.DBlib.Class;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    /// <summary>
    /// (DC2Type:json)
    /// </summary>
    public string Roles { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Discr { get; set; } = null!;

}
