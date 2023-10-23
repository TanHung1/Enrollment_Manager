using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IHolidayScheduleRepository
    {
        public List<HolidaySchedule> getall();

        public bool Create(HolidaySchedule holidaySchedule);
        public bool Update(HolidaySchedule holidaySchedule);
        public bool Delete(int Id);

        public List<HolidaySchedule> SearchByName(string name);
        public HolidaySchedule GetHolidaySchedule(int Id);

    }
    public class HolidayScheduleRepository : IHolidayScheduleRepository
    {
        private EnrollmentContext _dbcontext;

        public HolidayScheduleRepository(EnrollmentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Create(HolidaySchedule holidaySchedule)
        {
            _dbcontext.HolidaySchedules.Add(holidaySchedule);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            HolidaySchedule hs = _dbcontext.HolidaySchedules.FirstOrDefault(x => x.HolidayId == Id);
            _dbcontext.Remove(hs);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<HolidaySchedule> getall()
        {
            return _dbcontext.HolidaySchedules.ToList();
        }

        public HolidaySchedule GetHolidaySchedule(int Id)
        {
            HolidaySchedule hs = _dbcontext.HolidaySchedules.FirstOrDefault(x => x.HolidayId == Id);
            return hs;
        }

        public List<HolidaySchedule> SearchByName(string name)
        {
            return _dbcontext.HolidaySchedules.Where(x => x.NameHoliday.Contains(name)).ToList();
        }

        public bool Update(HolidaySchedule holidaySchedule)
        {
            HolidaySchedule hs = _dbcontext.HolidaySchedules.FirstOrDefault(x => x.HolidayId == holidaySchedule.HolidayId);
            if (hs != null)
            {
                _dbcontext.Entry(hs).CurrentValues.SetValues(holidaySchedule);
                _dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
