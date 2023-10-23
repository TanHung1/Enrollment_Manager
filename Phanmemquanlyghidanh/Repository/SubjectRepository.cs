using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ISubjectRepository
    {
        public bool Create(Subject subject);
        public bool Update(Subject subject);
        public bool Delete(int id);

        public List<Subject> SearchByName(string name);
        public List<Subject> GetAll();
        public Subject Get1Subject(int id);

        public List<SubjectCategory> GetSubjectCategories();
    }
    public class SubjectRepository : ISubjectRepository
    {
        private EnrollmentContext _dbContext;

        public SubjectRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            return true;
        }
        public List<SubjectCategory> GetSubjectCategories()
        {
            return _dbContext.SubjectCategories.ToList();
        }
        public bool Delete(int id)
        {
            Subject subject = _dbContext.Subjects.FirstOrDefault(x => x.SubjectId == id);
            _dbContext.Remove(subject);
            _dbContext.SaveChanges();
            return true;
        }

        public Subject Get1Subject(int id)
        {
            Subject subject = _dbContext.Subjects.FirstOrDefault(x => x.SubjectId == id);
            return subject;
        }

        public List<Subject> GetAll()
        {
            return _dbContext.Subjects.ToList();
        }

        public bool Update(Subject subject)
        {
            Subject sj = _dbContext.Subjects.FirstOrDefault(x => x.SubjectId == subject.SubjectId);
            if (sj != null)
            {
                _dbContext.Entry(sj).CurrentValues.SetValues(subject);
                _dbContext.SaveChanges();
            }
            return true;
        }

        public List<Subject> SearchByName(string name)
        {
            return _dbContext.Subjects.Where(x => x.Subject_Name.Contains(name)).ToList();
        }
    }
}
