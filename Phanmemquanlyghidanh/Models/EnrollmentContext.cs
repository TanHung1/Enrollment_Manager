using Microsoft.EntityFrameworkCore;

namespace Phanmemquanlyghidanh.Models
{
    public class EnrollmentContext : DbContext
    {

        public EnrollmentContext(DbContextOptions<EnrollmentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectCategory> SubjectCategories { get; set; }



        public DbSet<CheckOut> CheckOuts { get; set; }

        public DbSet<Mark> Marks { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<TypeMark> TypeMarks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<HolidaySchedule> HolidaySchedules { get; set; }


    }
}
