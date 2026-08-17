using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab1.EF
{
    [Table("Student")]
    public class Student
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int DepartmentID { get; set; }

        public double Cgpa { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public virtual Department Department { get; set; }
    }
}
