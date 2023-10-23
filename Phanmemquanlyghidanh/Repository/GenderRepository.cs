using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IGenderRepository
    {
        public List<Gender> getall();

        public bool CreateGender(Gender gender);
        public bool UpdateGender(Gender gender);
        public bool DeleteGender(int GenderId);

        public Gender GetGender(int GenderId);
    }
    public class GenderRepository : IGenderRepository
    {
        private EnrollmentContext _dbContext;

        public GenderRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateGender(Gender gender)
        {
            _dbContext.genders.Add(gender);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteGender(int GenderId)
        {
            Gender gd = _dbContext.genders.FirstOrDefault(x => x.GenderId == GenderId);
            _dbContext.genders.Remove(gd);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Gender> getall()
        {
            return _dbContext.genders.ToList();
        }

        public Gender GetGender(int GenderId)
        {
            Gender gd = _dbContext.genders.FirstOrDefault(x => x.GenderId == GenderId);
            return gd;
        }

        public bool UpdateGender(Gender gender)
        {
            Gender gd = _dbContext.genders.FirstOrDefault(x => x.GenderId == gender.GenderId);
            if (gd != null)
            {
                _dbContext.Entry(gd).CurrentValues.SetValues(gender);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
