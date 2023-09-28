using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> CreateCourse(Course course)
        {
            var created = _courseRepository.Create(course);
            if (!created)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Course_Id }, course);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.Course_Id)
            {
                return BadRequest();
            }

            var existingCourse = _courseRepository.GetById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            var updated = _courseRepository.Update(course);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var existingCourse = _courseRepository.GetById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            var deleted = _courseRepository.Delete(id);
            if (!deleted)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}