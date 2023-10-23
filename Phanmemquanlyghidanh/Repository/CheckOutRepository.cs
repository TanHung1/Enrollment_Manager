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
        private EnrollmentContext _dbContext;

        public CheckOutRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateCheckOut(CheckOut checkOut)
        {
            _dbContext.CheckOuts.Add(checkOut);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCheckOut(int Id)
        {
            CheckOut checkOut = _dbContext.CheckOuts.FirstOrDefault(x => x.CheckOutId == Id);
            _dbContext.Remove(checkOut);
            _dbContext.SaveChanges();
            return true;
        }

        public List<CheckOut> GetAll()
        {
            return _dbContext.CheckOuts.ToList();
        }

        public CheckOut GetCheckOutById(int Id)
        {
            CheckOut checkOut = _dbContext.CheckOuts.FirstOrDefault(x => x.CheckOutId == Id);
            return checkOut;
        }

        public bool UpdateCheckOut(CheckOut checkOut)
        {
            CheckOut co = _dbContext.CheckOuts.FirstOrDefault(x => x.CheckOutId == checkOut.CheckOutId);
            if (co != null)
            {
                _dbContext.Entry(co).CurrentValues.SetValues(checkOut);
                decimal discountAmount = checkOut.Price * (checkOut.Discount / 100);
                co.Price -= discountAmount;
                if (checkOut.Price - checkOut.PricePaid == checkOut.RemainingPrice && checkOut.RemainingPrice == 0 && checkOut.RemainingPrice > 0)
                {
                    co.StatusCheckOut = "Đã thanh toán";
                }
                else if (checkOut.PricePaid == 0)
                {
                    co.StatusCheckOut = "Chưa thanh toán";
                }
                else
                {
                    co.StatusCheckOut = "Chưa thanh toán dử";
                }
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
