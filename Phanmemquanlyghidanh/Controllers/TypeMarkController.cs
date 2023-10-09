using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeMarkController : ControllerBase
    {
        private readonly ITypeMarkRepository _typeMarkRepository;

        public TypeMarkController(ITypeMarkRepository typeMarkRepository)
        {
            _typeMarkRepository = typeMarkRepository;
        }

        [HttpGet]
        public IActionResult GetMarkList()
        {
            var marks = _typeMarkRepository.GetMarkList();
            return Ok(marks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var typeMark = _typeMarkRepository.GetMarkId(id);
            if (typeMark == null)
            {
                return NotFound("không tìm thấy loại điểm");
            }
            return Ok(typeMark);
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _typeMarkRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public IActionResult Create(TypeMark typemark)
        {
            if (ModelState.IsValid)
            {
                _typeMarkRepository.Create(typemark);
                return Ok("Tạo loại điểm thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TypeMark typemark)
        {
            typemark.TypeID = id;
            var result = _typeMarkRepository.Update(typemark);
            if (result)
                return Ok("Cập nhật thành công");
            else
                return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _typeMarkRepository.GetMarkId(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _typeMarkRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }
    }
}