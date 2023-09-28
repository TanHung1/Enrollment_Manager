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
            var typeMark = _typeMarkRepository.GetMark(id);
            if (typeMark == null)
            {
                return NotFound();
            }
            return Ok(typeMark);
        }

        [HttpPost]
        public IActionResult Create(TypeMark typemark)
        {
            var result = _typeMarkRepository.Create(typemark);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TypeMark typemark)
        {
            typemark.TypeID = id;
            var result = _typeMarkRepository.Update(typemark);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _typeMarkRepository.Delete(id);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}