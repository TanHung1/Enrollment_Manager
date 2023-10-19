using Phanmemquanlyghidanh.Models;
namespace Phanmemquanlyghidanh.Repository
{
    public interface IStatusRoomRepository
    {
        public bool Create(StatusRoom statusRoom);

        public bool Update(StatusRoom statusRoom);

        public List<StatusRoom> SearchByName(string name);
        public StatusRoom GetById(int id);
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
            StatusRoom s = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoomId == id);
            _dbcontext.Remove(s);
            _dbcontext.SaveChanges();
            return true;
        }



        public List<StatusRoom> GetAll()
        {
            return _dbcontext.StatusRooms.ToList();
        }

        public StatusRoom GetById(int id)
        {
            StatusRoom st = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoomId == id);
            return st;
        }

        public List<StatusRoom> SearchByName(string name)
        {
            return _dbcontext.StatusRooms.Where(x => x.StatusRoom_Name.Contains(name)).ToList();
        }

        public bool Update(StatusRoom statusRoom)
        {
            StatusRoom s = _dbcontext.StatusRooms.FirstOrDefault(x => x.StatusRoomId == statusRoom.StatusRoomId);
            if (s == null)
            {
                _dbcontext.Entry(s).CurrentValues.SetValues(statusRoom);
                _dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
