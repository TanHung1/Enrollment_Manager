using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly IMarkRepository _markRepository;

        public MarksController(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        [HttpGet]
        public IEnumerable<Mark> GetMarks()
        {
            return _markRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Mark> GetMark(int id)
        {
            var mark = _markRepository.Get1Mark(id);

            if (mark == null)
            {
                return NotFound("Không tìm thấy!");
            }

            return mark;
        }

        [HttpPost]
        public ActionResult<Mark> CreateMark(Mark mark)
        {
            if (ModelState.IsValid)
            {
                mark.AverageColumnPoint = _markRepository.CalculateAverageColumnPoint(mark);
                _markRepository.Create(mark);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMark(int id, Mark mark)
        {
            mark.MarkId = id;
            mark.AverageColumnPoint = _markRepository.CalculateAverageColumnPoint(mark);
            var markRepository = _markRepository.Update(mark);
            if (markRepository)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMark(int id)
        {
            var result = _markRepository.Get1Mark(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id");

            }
            var delete = _markRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại ");
        }


    }
}