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
                return NotFound();
            }

            return subject;
        }

        [HttpPost]
        public ActionResult<Subject> CreateSubject(Subject subject)
        {
            if (_subjectRepository.Create(subject))
            {
                return CreatedAtAction(nameof(GetSubject), new { id = subject.Subject_Id }, subject);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, Subject subject)
        {
            if (id != subject.Subject_Id)
            {
                return BadRequest();
            }

            if (_subjectRepository.Update(subject))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            if (_subjectRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}