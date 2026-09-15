using System;
using System.Collections.Generic;

namespace Final1.Data.Entities;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialization { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
