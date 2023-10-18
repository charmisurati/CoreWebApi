using System;
using System.Collections.Generic;

namespace CoreWebApi.Database;

public partial class ProductsDatum
{
    public int ProductDataId { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Price { get; set; }

    public virtual Product? Category { get; set; }
}
