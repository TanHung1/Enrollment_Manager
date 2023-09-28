using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Schedule> schedules = _scheduleRepository.GetAll();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Schedule schedule = _scheduleRepository.GetById(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                bool created = _scheduleRepository.Create(schedule);
                if (created)
                    return Ok(schedule);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                Schedule existingSchedule = _scheduleRepository.GetById(id);
                if (existingSchedule == null)
                    return NotFound();

                schedule.Schedule_Id = existingSchedule.Schedule_Id; // Ensure the ID remains unchanged

                bool updated = _scheduleRepository.Update(schedule);
                if (updated)
                    return Ok(schedule);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _scheduleRepository.Delete(id);
            if (deleted)
                return NoContent();

            return BadRequest();
        }
    }
}