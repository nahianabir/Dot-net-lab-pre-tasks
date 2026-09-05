using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Company.EF.Tables;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ValidateNever]
    public virtual Department Department { get; set; } = null!;
}
