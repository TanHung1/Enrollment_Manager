using Microsoft.EntityFrameworkCore;
namespace Phanmemquanlyghidanh.Models
{
    public class EnrollmentDBContext : DbContext
    {

        public EnrollmentDBContext(DbContextOptions<EnrollmentDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectCategory> SubjectCategories { get; set; }

        public DbSet<StatusRoom> StatusRooms { get; set; }

        public DbSet<CheckOut> CheckOutRooms { get; set; }
    }
}
