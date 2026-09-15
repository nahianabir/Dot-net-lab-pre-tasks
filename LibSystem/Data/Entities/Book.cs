using System;
using System.Collections.Generic;

namespace LibSystem.Data.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int AvailableCopies { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual Category Category { get; set; } = null!;
}
