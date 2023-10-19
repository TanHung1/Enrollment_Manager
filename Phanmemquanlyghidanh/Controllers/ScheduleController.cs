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
                return NotFound("Không tìm thấy Id");

            return Ok(schedule);
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _scheduleRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
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

            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Schedule schedule)
        {
            schedule.ScheduleId = id;
            var result = _scheduleRepository.Update(schedule);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _scheduleRepository.GetById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id");
            }
            var delete = _scheduleRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}