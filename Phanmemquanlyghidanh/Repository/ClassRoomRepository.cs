using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IClassRoomRepository
    {
        public bool Create(ClassRoom room);
        public bool Update(ClassRoom room);
        public bool Delete(int Id);

        public List<ClassRoom> GetAll();
        public List<ClassRoom> SearchByName(string name);
        public ClassRoom GetClassRoom(int id);
    }
    public class ClassRoomRepository : IClassRoomRepository
    {
        private EnrollmentContext _dbContext;

        public ClassRoomRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(ClassRoom room)
        {
            _dbContext.ClassRooms.Add(room);
            room.StatusRoom = "Mở";
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            ClassRoom CR = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoomId == Id);
            _dbContext.Remove(CR);
            _dbContext.SaveChanges();
            return true;
        }

        public List<ClassRoom> GetAll()
        {
            return _dbContext.ClassRooms.ToList();
        }

        public ClassRoom GetClassRoom(int id)
        {
            ClassRoom CR = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoomId == id);
            return CR;
        }

        public List<ClassRoom> SearchByName(string name)
        {
            return _dbContext.ClassRooms.Where(x => x.ClassRoomName.Contains(name)).ToList();
        }

        public bool Update(ClassRoom room)
        {
            ClassRoom classRoom = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoomId == room.ClassRoomId);
            if (classRoom != null)
            {
                _dbContext.Entry(classRoom).CurrentValues.SetValues(room);
                if (room.CurrentStudent == room.NumberofStudent)
                {
                    classRoom.StatusRoom = "Đóng";
                }
                else if (room.CurrentStudent < room.NumberofStudent)
                {
                    classRoom.StatusRoom = "Mở";
                }
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
