using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ICheckOutRepository
    {
        public List<CheckOut> GetAll();

        public bool CreateCheckOut(CheckOut checkOut);

        public bool UpdateCheckOut(CheckOut checkOut);
        public bool DeleteCheckOut(int Id);

        public CheckOut GetCheckOutById(int Id);
    }
    public class CheckOutRepository : ICheckOutRepository
    {
        private EnrollmentDBContext _dbContext;

        public CheckOutRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateCheckOut(CheckOut checkOut)
        {
            _dbContext.CheckOutRooms.Add(checkOut);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCheckOut(int Id)
        {
            CheckOut checkOut = _dbContext.CheckOutRooms.FirstOrDefault(x => x.CheckOut_Id == Id);
            _dbContext.Remove(checkOut);
            _dbContext.SaveChanges();
            return true;
        }

        public List<CheckOut> GetAll()
        {
            return _dbContext.CheckOutRooms.ToList();
        }

        public CheckOut GetCheckOutById(int Id)
        {
            CheckOut checkOut = _dbContext.CheckOutRooms.FirstOrDefault(x => x.CheckOut_Id == Id);
            return checkOut;
        }

        public bool UpdateCheckOut(CheckOut checkOut)
        {
            CheckOut co = _dbContext.CheckOutRooms.FirstOrDefault(x => x.CheckOut_Id == checkOut.CheckOut_Id);
            if (co != null)
            {
                _dbContext.Entry(co).CurrentValues.SetValues(checkOut);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
