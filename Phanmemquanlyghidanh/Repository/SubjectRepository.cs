using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ISubjectRepository
    {
        public bool Create(Subject subject);
        public bool Update(Subject subject);
        public bool Delete(int id);

        public List<Subject> GetAll();
        public Subject Get1Subject(int id);
    }
    public class SubjectRepository : ISubjectRepository
    {
        private EnrollmentDBContext _dbContext;

        public SubjectRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Subject subject = _dbContext.Subjects.FirstOrDefault(x => x.Subject_Id == id);
            _dbContext.Remove(subject);
            _dbContext.SaveChanges();
            return true;
        }

        public Subject Get1Subject(int id)
        {
            Subject subject = _dbContext.Subjects.FirstOrDefault(x => x.Subject_Id == id);
            return subject;
        }

        public List<Subject> GetAll()
        {
            return _dbContext.Subjects.ToList();
        }

        public bool Update(Subject subject)
        {
            Subject sj = _dbContext.Subjects.FirstOrDefault(x => x.Subject_Id == subject.Subject_Id);
            if (sj != null)
            {
                _dbContext.Entry(sj).CurrentValues.SetValues(subject);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
