using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();

        public bool Create(Course course);
        public bool Update(Course course);
        public bool Delete(int Id);
        public Course GetById(int Id);

        public List<Course> SearchByName(string name);

    }
    public class CourseRepository : ICourseRepository
    {
        private EnrollmentDBContext _dbcontext;

        public CourseRepository(EnrollmentDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Create(Course course)
        {
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Course course = _dbcontext.Courses.FirstOrDefault(x => x.CourseId == Id);
            _dbcontext.Remove(course);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<Course> GetAll()
        {
            return _dbcontext.Courses.ToList();
        }

        public Course GetById(int Id)
        {
            Course course = _dbcontext.Courses.FirstOrDefault(x => x.CourseId == Id);
            return course;
        }

        public List<Course> SearchByName(string name)
        {
            return _dbcontext.Courses.Where(x => x.CourseName.Contains(name)).ToList();
        }

        public bool Update(Course course)
        {
            Course cs = _dbcontext.Courses.FirstOrDefault(x => x.CourseId == course.CourseId);
            if (cs != null)
            {
                _dbcontext.Entry(cs).CurrentValues.SetValues(course);
                _dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
