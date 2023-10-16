using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IStatusCheckOutRepository
    {
        public List<StatusCheckOut> GetAll();

        public bool CreateStatusCheckOut(StatusCheckOut statusCheckOut);

        public bool UpdateStatusCheckOut(StatusCheckOut statusCheckOut);
        public bool DeleteStatusCheckOut(int Id);

        public StatusCheckOut GetStatusCheckOutById(int Id);
    }
    public class StatusCheckOutRepository : IStatusCheckOutRepository
    {
        private EnrollmentDBContext _dbContext;

        public StatusCheckOutRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateStatusCheckOut(StatusCheckOut statusCheckOut)
        {
            _dbContext.StatusCheckouts.Add(statusCheckOut);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteStatusCheckOut(int Id)
        {
            StatusCheckOut statusCheckOut = _dbContext.StatusCheckouts.FirstOrDefault(x => x.StatusCheckOutId == Id);
            _dbContext.Remove(statusCheckOut);
            _dbContext.SaveChanges();
            return true;
        }

        public List<StatusCheckOut> GetAll()
        {
            return _dbContext.StatusCheckouts.ToList();
        }

        public StatusCheckOut GetStatusCheckOutById(int Id)
        {
            StatusCheckOut statusCheckOut = _dbContext.StatusCheckouts.FirstOrDefault(x => x.StatusCheckOutId == Id);
            return statusCheckOut;
        }

        public bool UpdateStatusCheckOut(StatusCheckOut statusCheckOut)
        {
            StatusCheckOut co = _dbContext.StatusCheckouts.FirstOrDefault(x => x.StatusCheckOutId == statusCheckOut.StatusCheckOutId);
            if (co != null)
            {
                _dbContext.Entry(co).CurrentValues.SetValues(statusCheckOut);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
