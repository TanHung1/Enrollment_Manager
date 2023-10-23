using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IMarkRepository
    {
        public bool Create(Mark mark);

        public bool Update(Mark mark);
        public bool Delete(int Id);
        public List<Mark> GetAll();
        public Mark Get1Mark(int id);

        public decimal CalculateAverageColumnPoint(Mark mark);
    }
    public class MarkRepository : IMarkRepository
    {
        private EnrollmentContext _dbContext;

        public MarkRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal CalculateAverageColumnPoint(Mark mark)
        {
            int count = 0;
            decimal sum = 0;

            if (mark.FirstColumnPoint.HasValue)
            {
                sum += mark.FirstColumnPoint.Value;
                count++;
            }

            if (mark.SecondColumnPoint.HasValue)
            {
                sum += mark.SecondColumnPoint.Value;
                count++;
            }

            if (mark.ThirdColumnPoint.HasValue)
            {
                sum += mark.ThirdColumnPoint.Value;
                count++;
            }

            if (mark.FourthColumnPoint.HasValue)
            {
                sum += mark.FourthColumnPoint.Value;
                count++;
            }

            if (mark.FinalExamPoint1.HasValue)
            {
                sum += mark.FinalExamPoint1.Value * 2;
                count++;
            }

            if (mark.FinalExamPoint2.HasValue)
            {
                sum += mark.FinalExamPoint2.Value * 2;
                count++;
            }

            if (count == 0)
            {
                return 0;
            }

            decimal averageColumnPoint = sum / count;
            return averageColumnPoint;
        }

        public bool Create(Mark mark)
        {
            _dbContext.Marks.Add(mark);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Mark mark = _dbContext.Marks.FirstOrDefault(x => x.MarkId == Id);
            _dbContext.Remove(mark);
            _dbContext.SaveChanges();
            return true;
        }

        public Mark Get1Mark(int id)
        {
            Mark mark = _dbContext.Marks.FirstOrDefault(x => x.MarkId == id);
            return mark;
        }

        public List<Mark> GetAll()
        {
            return _dbContext.Marks.ToList();
        }

        public bool Update(Mark mark)
        {
            Mark m = _dbContext.Marks.FirstOrDefault(x => x.MarkId == mark.MarkId);
            if (m != null)
            {
                _dbContext.Entry(m).CurrentValues.SetValues(mark);
                _dbContext.SaveChanges();
            }
            return true;
        }


    }
}
