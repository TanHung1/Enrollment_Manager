using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectCategoriesController : ControllerBase
    {
        private readonly ISubjectCategoryRepository _subjectCategoryRepository;

        public SubjectCategoriesController(ISubjectCategoryRepository subjectCategoryRepository)
        {
            _subjectCategoryRepository = subjectCategoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subjectCategories = _subjectCategoryRepository.GetAll();
            return Ok(subjectCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subjectCategory = _subjectCategoryRepository.GetById(id);
            if (subjectCategory == null)
            {
                return NotFound("Không tìm thấy Id cần tìm");
            }
            return Ok(subjectCategory);
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _subjectCategoryRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public IActionResult Create(SubjectCategory subjectCategory)
        {
            if (ModelState.IsValid)
            {
                _subjectCategoryRepository.Create(subjectCategory);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SubjectCategory subjectCategory)
        {
            subjectCategory.SubjectCategoryId = id;
            var result = _subjectCategoryRepository.Update(subjectCategory);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingSubjectCategory = _subjectCategoryRepository.GetById(id);
            if (existingSubjectCategory == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var deleted = _subjectCategoryRepository.Delete(id);
            if (deleted)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}