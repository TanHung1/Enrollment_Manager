using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{

    public interface ISubjectCategoryRepository
    {
        public bool Create(SubjectCategory subjectCategory);

        public SubjectCategory GetById(int id);
        public bool Update(SubjectCategory subjectCategory);

        public List<SubjectCategory> SearchByName(string name);
        public bool Delete(int id);
        public List<SubjectCategory> GetAll();
    }

    public class SubjectCategoryRepository : ISubjectCategoryRepository
    {
        private EnrollmentContext _dbContext;

        public SubjectCategoryRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(SubjectCategory subjectCategory)
        {
            _dbContext.SubjectCategories.Add(subjectCategory);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategoryId == id);
            _dbContext.Remove(s);
            _dbContext.SaveChanges();
            return true;
        }

        public List<SubjectCategory> GetAll()
        {
            return _dbContext.SubjectCategories.ToList();
        }

        public SubjectCategory GetById(int id)
        {
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategoryId == id);
            return s;
        }

        public List<SubjectCategory> SearchByName(string name)
        {
            return _dbContext.SubjectCategories.Where(x => x.SubjectCategory_Name.Contains(name)).ToList();
        }

        public bool Update(SubjectCategory subjectCategory)
        {
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategoryId == subjectCategory.SubjectCategoryId);
            if (s != null)
            {
                _dbContext.Entry(s).CurrentValues.SetValues(subjectCategory);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
