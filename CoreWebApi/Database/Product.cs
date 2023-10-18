using System;
using System.Collections.Generic;

namespace CoreWebApi.Database;

public partial class Product
{
    public int ProductId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<ProductsDatum> ProductsData { get; set; } = new List<ProductsDatum>();
}
