using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace FinalLab1.EF
{
    [Table("Department")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual List<Student>Students { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           // modelBuilder.Entity<Department>().HasData(new Department() { Id=1, Name="FST" },
              //  new Department() {Id=2, Name="FE" } );
        //}
    }
}
