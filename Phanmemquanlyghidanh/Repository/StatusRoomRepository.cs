using Phanmemquanlyghidanh.Models;
namespace Phanmemquanlyghidanh.Repository
{
    public interface IStatusRoomRepository
    {
        public bool Create(StatusRoom statusRoom);

        public bool Update(StatusRoom statusRoom);

        public StatusRoom FindById(int id);

        public bool Delete(int id);

        public List<StatusRoom> GetAll();
    }
    public class StatusRoomRepository : IStatusRoomRepository
    {
        private EnrollmentDBContext _dbcontext;

        public StatusRoomRepository(EnrollmentDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Create(StatusRoom statusRoom)
        {
            _dbcontext.StatusRooms.Add(statusRoom);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            StatusRoom s = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoom_Id == id);
            _dbcontext.Remove(s);
            _dbcontext.SaveChanges();
            return true;
        }

        public StatusRoom FindById(int id)
        {
            StatusRoom s = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoom_Id == id);
            return s;
        }

        public List<StatusRoom> GetAll()
        {
            return _dbcontext.StatusRooms.ToList();
        }

        public bool Update(StatusRoom statusRoom)
        {
            StatusRoom s = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoom_Id == statusRoom.StatusRoom_Id);
            if (s == null)
            {
                _dbcontext.Entry(s).CurrentValues.SetValues(statusRoom);
                _dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
