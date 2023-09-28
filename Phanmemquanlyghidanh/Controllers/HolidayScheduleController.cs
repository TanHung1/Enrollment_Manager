using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/holidayschedules")]
    public class HolidayScheduleController : ControllerBase
    {
        private readonly IHolidayScheduleRepository _holidayScheduleRepository;

        public HolidayScheduleController(IHolidayScheduleRepository holidayScheduleRepository)
        {
            _holidayScheduleRepository = holidayScheduleRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var holidaySchedules = _holidayScheduleRepository.getall();
            return Ok(holidaySchedules);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var holidaySchedule = _holidayScheduleRepository.GetHolidaySchedule(id);
            if (holidaySchedule == null)
            {
                return NotFound();
            }
            return Ok(holidaySchedule);
        }

        [HttpPost]
        public IActionResult Create(HolidaySchedule holidaySchedule)
        {
            if (ModelState.IsValid)
            {
                _holidayScheduleRepository.Create(holidaySchedule);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HolidaySchedule holidaySchedule)
        {
            if (id != holidaySchedule.HolidayId)
            {
                return BadRequest();
            }

            var existingHolidaySchedule = _holidayScheduleRepository.GetHolidaySchedule(id);
            if (existingHolidaySchedule == null)
            {
                return NotFound();
            }

            existingHolidaySchedule.NameHoliday = holidaySchedule.NameHoliday;
            existingHolidaySchedule.StartDay = holidaySchedule.StartDay;
            existingHolidaySchedule.EndDate = holidaySchedule.EndDate;

            _holidayScheduleRepository.Update(existingHolidaySchedule);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingHolidaySchedule = _holidayScheduleRepository.GetHolidaySchedule(id);
            if (existingHolidaySchedule == null)
            {
                return NotFound();
            }

            _holidayScheduleRepository.Delete(id);
            return Ok();
        }
    }
}