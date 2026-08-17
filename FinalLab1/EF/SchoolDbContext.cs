using Microsoft.EntityFrameworkCore;

namespace FinalLab1.EF
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) :
            base(options) { }

        public virtual DbSet<Department> Department { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}
