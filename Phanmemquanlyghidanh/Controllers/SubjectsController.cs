using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Subject> GetSubject(int id)
        {
            var subject = _subjectRepository.Get1Subject(id);

            if (subject == null)
            {
                return NotFound("Không tìm thấy");
            }

            return subject;
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _subjectRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public ActionResult<Subject> CreateSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectRepository.Create(subject);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, Subject subject)
        {
            subject.SubjectId = id;
            var result = _subjectRepository.Update(subject);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var result = _subjectRepository.Get1Subject(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _subjectRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}