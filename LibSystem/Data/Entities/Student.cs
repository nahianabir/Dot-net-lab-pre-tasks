using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibSystem.Data.Entities;

public partial class Student
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}
