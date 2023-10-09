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
                return NotFound("Không tìm thấy lịch nghỉ");
            }
            return Ok(holidaySchedule);
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _holidayScheduleRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public IActionResult Create(HolidaySchedule holidaySchedule)
        {
            if (ModelState.IsValid)
            {
                _holidayScheduleRepository.Create(holidaySchedule);
                return Ok("Tạo thời khóa biểu thành công");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HolidaySchedule holidaySchedule)
        {
            holidaySchedule.HolidayId = id;
            var result = _holidayScheduleRepository.Update(holidaySchedule);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _holidayScheduleRepository.GetHolidaySchedule(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _holidayScheduleRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}