using System;
using System.Collections.Generic;

namespace Final1.Data.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? DoctorId { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
