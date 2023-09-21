using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{

    public interface ISubjectCategoryRepository
    {
        public bool Create(SubjectCategory subjectCategory);

        public SubjectCategory GetById(int id);
        public bool Update(SubjectCategory subjectCategory);

        public bool Delete(int id);
        List<SubjectCategory> GetAll();
    }

    public class SubjectCategoryRepository : ISubjectCategoryRepository
    {
        private EnrollmentDBContext _dbContext;

        public SubjectCategoryRepository(EnrollmentDBContext dbContext)
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
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategory_Id == id);
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
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategory_Id == id);
            return s;
        }

        public bool Update(SubjectCategory subjectCategory)
        {
            SubjectCategory s = _dbContext.SubjectCategories.FirstOrDefault(x => x.SubjectCategory_Id == subjectCategory.SubjectCategory_Id);
            if (s != null)
            {
                _dbContext.Entry(s).CurrentValues.SetValues(subjectCategory);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
