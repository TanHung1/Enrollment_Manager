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
    }
    public class MarkRepository : IMarkRepository
    {
        private EnrollmentDBContext _dbContext;

        public MarkRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
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
