using System.Data.Entity;

namespace WebApplication1.Models
{
    public partial class AcademyContext : DbContext
    {
        public AcademyContext()
            : base("name=AcademyContext")
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
