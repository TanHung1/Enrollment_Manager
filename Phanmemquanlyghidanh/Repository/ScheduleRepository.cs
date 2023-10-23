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


    }
    public class ScheduleRepository : IScheduleRepository
    {
        private EnrollmentContext _dbContext;

        public ScheduleRepository(EnrollmentContext dbcontext)
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
            Schedule schedule = _dbContext.Schedules.FirstOrDefault(x => x.ScheduleId == Id);
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
            Schedule schedule = _dbContext.Schedules.FirstOrDefault(x => x.ScheduleId == id);
            return schedule;
        }



        public bool Update(Schedule schedule)
        {
            Schedule schedule1 = _dbContext.Schedules.FirstOrDefault(x => x.ScheduleId == schedule.ScheduleId);
            if (schedule1 != null)
            {
                _dbContext.Entry(schedule1).CurrentValues.SetValues(schedule);
                _dbContext.SaveChanges(true);
            }
            return true;
        }
    }
}
