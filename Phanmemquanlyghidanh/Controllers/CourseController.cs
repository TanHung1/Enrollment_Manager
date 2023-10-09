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
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _courseRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound("Không có khóa học cần tìm");
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Create(course);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, Course course)
        {
            course.Course_Id = id;
            var result = _courseRepository.Update(course);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var result = _courseRepository.GetById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _courseRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}