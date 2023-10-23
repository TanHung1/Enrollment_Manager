using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;
namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolYearController : Controller
    {
        private readonly ISchoolYearRepository _shoolYearRepository;
        public SchoolYearController(ISchoolYearRepository shoolYearRepository)
        {
            _shoolYearRepository = shoolYearRepository;
        }
        [HttpGet]
        public IEnumerable<SchoolYear> GetAll()
        {
            return _shoolYearRepository.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<SchoolYear> GetById(int id)
        {
            var SchoolYear = _shoolYearRepository.GetById(id);
            if (SchoolYear == null)
            {
                return NotFound("Không tìm thấy");
            }
            return SchoolYear;
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var searchname = _shoolYearRepository.SearchName(name);
            if (!searchname.Any())
            {
                return NotFound("Không tìm thấy");
            }
            return Ok(searchname);
        }
        [HttpPost]
        public ActionResult<SchoolYear> CreateSchoolYear(SchoolYear schoolYear)
        {
            if (ModelState.IsValid)
            {
                _shoolYearRepository.Create(schoolYear);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }
        [HttpPut]
        public IActionResult UpdateSchoolYear(int id, SchoolYear schoolYear)
        {
            schoolYear.SchooYearId = id;
            var result = _shoolYearRepository.Update(schoolYear);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var result = _shoolYearRepository.GetById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _shoolYearRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}
