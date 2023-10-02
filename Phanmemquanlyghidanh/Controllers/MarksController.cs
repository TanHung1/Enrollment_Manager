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
                return NotFound();
            }

            return mark;
        }

        [HttpPost]
        public ActionResult<Mark> CreateMark(Mark mark)
        {
            if (_markRepository.Create(mark))
            {
                return CreatedAtAction(nameof(GetMark), new { id = mark.MarkId }, mark);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMark(int id, Mark mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest();
            }

            if (_markRepository.Update(mark))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMark(int id)
        {
            if (_markRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}