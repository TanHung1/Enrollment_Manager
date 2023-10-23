using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ISchoolYearRepository
    {
        public List<SchoolYear> GetAll();

        public bool Create(SchoolYear schoolYear);
        public bool Update(SchoolYear schoolYear);
        public bool Delete(int SchoolYearId);

        public SchoolYear GetById(int id);
        public List<SchoolYear> SearchName(string name);
    }
    public class SchoolYearRepository : ISchoolYearRepository
    {
        private EnrollmentContext _dbcontext;

        public SchoolYearRepository(EnrollmentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Create(SchoolYear schoolYear)
        {
            _dbcontext.SchoolYears.Add(schoolYear);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Delete(int SchoolYearId)
        {
            SchoolYear schoolYear = _dbcontext.SchoolYears.FirstOrDefault(x => x.SchooYearId == SchoolYearId);
            _dbcontext.Remove(schoolYear);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<SchoolYear> GetAll()
        {
            return _dbcontext.SchoolYears.ToList();
        }

        public SchoolYear GetById(int id)
        {
            SchoolYear schoolYear = _dbcontext.SchoolYears.FirstOrDefault(x => x.SchooYearId == id);
            return schoolYear;
        }

        public List<SchoolYear> SearchName(string name)
        {
            return _dbcontext.SchoolYears.Where(x => x.SchoolYearName.Contains(name)).ToList();
        }

        public bool Update(SchoolYear schoolYear)
        {
            SchoolYear sy = _dbcontext.SchoolYears.FirstOrDefault(x => x.SchooYearId == schoolYear.SchooYearId);
            if (sy != null)
            {
                _dbcontext.Entry(sy).CurrentValues.SetValues(schoolYear);
                _dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
