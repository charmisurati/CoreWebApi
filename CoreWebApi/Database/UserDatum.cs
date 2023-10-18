using System;
using System.Collections.Generic;

namespace CoreWebApi.Database;

public partial class UserDatum
{
    public int UId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
