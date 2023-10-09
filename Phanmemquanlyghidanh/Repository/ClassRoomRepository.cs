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
        private EnrollmentDBContext _dbContext;

        public ClassRoomRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(ClassRoom room)
        {
            _dbContext.ClassRooms.Add(room);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            ClassRoom CR = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoom_Id == Id);
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
            ClassRoom CR = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoom_Id == id);
            return CR;
        }

        public List<ClassRoom> SearchByName(string name)
        {
            return _dbContext.ClassRooms.Where(x => x.ClassRoom_Name.Contains(name)).ToList();
        }

        public bool Update(ClassRoom room)
        {
            ClassRoom classRoom = _dbContext.ClassRooms.FirstOrDefault(x => x.ClassRoom_Id == room.ClassRoom_Id);
            if (classRoom != null)
            {
                _dbContext.Entry(classRoom).CurrentValues.SetValues(room);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
