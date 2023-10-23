using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;

        public GenderController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Gender>> GetAllGenders()
        {
            var genders = _genderRepository.getall();
            return Ok(genders);
        }

        [HttpGet("{id}")]
        public ActionResult<Gender> GetGenderById(int id)
        {
            var gender = _genderRepository.GetGender(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(gender);
        }

        [HttpPost]
        public ActionResult<Gender> CreateGender(Gender gender)
        {
            var createdGender = _genderRepository.CreateGender(gender);
            if (!createdGender)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetGenderById), new { id = gender.GenderId }, gender);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGender(int id, Gender gender)
        {
            if (id != gender.GenderId)
            {
                return BadRequest();
            }
            var updatedGender = _genderRepository.UpdateGender(gender);
            if (!updatedGender)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGender(int id)
        {
            var deletedGender = _genderRepository.DeleteGender(id);
            if (deletedGender)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}