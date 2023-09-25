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
                return NotFound();
            }
            return Ok(subjectCategory);
        }

        [HttpPost]
        public IActionResult Create(SubjectCategory subjectCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var created = _subjectCategoryRepository.Create(subjectCategory);
            if (created)
            {
                return CreatedAtAction(nameof(GetById), new { id = subjectCategory.SubjectCategory_Id }, subjectCategory);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SubjectCategory subjectCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != subjectCategory.SubjectCategory_Id)
            {
                return BadRequest();
            }
            var existingSubjectCategory = _subjectCategoryRepository.GetById(id);
            if (existingSubjectCategory == null)
            {
                return NotFound();
            }
            var updated = _subjectCategoryRepository.Update(subjectCategory);
            if (updated)
            {
                return NoContent();
            }
            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingSubjectCategory = _subjectCategoryRepository.GetById(id);
            if (existingSubjectCategory == null)
            {
                return NotFound();
            }
            var deleted = _subjectCategoryRepository.Delete(id);
            if (deleted)
            {
                return NoContent();
            }
            return StatusCode(500);
        }
    }
}