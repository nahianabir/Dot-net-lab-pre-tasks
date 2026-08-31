using Microsoft.EntityFrameworkCore;

namespace FinalLab1.EF
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) :
            base(options) { }

        public virtual DbSet<Department> Department { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo()
                {
                   Id = 1,Name="Abir", Email="abir@mail.com",Password="1122",Role="Admin"
                }
                
                );


        }
       
    }
}
