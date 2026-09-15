using System;
using System.Collections.Generic;

namespace LibSystem.Data.Entities;

public partial class Borrow
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
