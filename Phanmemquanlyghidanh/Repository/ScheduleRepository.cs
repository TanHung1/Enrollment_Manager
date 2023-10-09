using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IScheduleRepository
    {
        public List<Schedule> GetAll();

        public Schedule GetById(int id);

        public bool Create(Schedule schedule);
        public bool Update(Schedule schedule);
        public bool Delete(int Id);

        public List<Schedule> SearchByName(string name);
    }
    public class ScheduleRepository : IScheduleRepository
    {
        private EnrollmentDBContext _dbContext;

        public ScheduleRepository(EnrollmentDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public bool Create(Schedule schedule)
        {
            _dbContext.Schedules.Add(schedule);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Schedule schedule = _dbContext.Schedules.FirstOrDefault(x => x.Schedule_Id == Id);
            _dbContext.Schedules.Remove(schedule);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Schedule> GetAll()
        {
            return _dbContext.Schedules.ToList();
        }

        public Schedule GetById(int id)
        {
            Schedule schedule = _dbContext.Schedules.FirstOrDefault(x => x.Schedule_Id == id);
            return schedule;
        }

        public List<Schedule> SearchByName(string name)
        {
            return _dbContext.Schedules.Where(x => x.Schedule_Name.Contains(name)).ToList();
        }

        public bool Update(Schedule schedule)
        {
            Schedule schedule1 = _dbContext.Schedules.FirstOrDefault(x => x.Schedule_Id == schedule.Schedule_Id);
            if (schedule1 != null)
            {
                _dbContext.Entry(schedule1).CurrentValues.SetValues(schedule);
                _dbContext.SaveChanges(true);
            }
            return true;
        }
    }
}
