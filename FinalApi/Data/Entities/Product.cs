using System;
using System.Collections.Generic;

namespace FinalApi.Data.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;
}
