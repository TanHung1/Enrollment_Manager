using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            return _roleRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetRole(int id)
        {
            var role = _roleRepository.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _roleRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public ActionResult<Role> CreateRole(Role role)
        {
            if (_roleRepository.Create(role))
            {
                return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            if (_roleRepository.Update(role))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            if (_roleRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}