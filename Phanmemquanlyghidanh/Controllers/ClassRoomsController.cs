using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassRoomsController : ControllerBase
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public ClassRoomsController(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        [HttpGet]
        public IEnumerable<ClassRoom> GetClassRooms()
        {
            return _classRoomRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ClassRoom> GetClassRoom(int id)
        {
            var classRoom = _classRoomRepository.GetClassRoom(id);

            if (classRoom == null)
            {
                return NotFound();
            }

            return classRoom;
        }

        [HttpPost]
        public ActionResult<ClassRoom> CreateClassRoom(ClassRoom classRoom)
        {
            if (_classRoomRepository.Create(classRoom))
            {
                return CreatedAtAction(nameof(GetClassRoom), new { id = classRoom.ClassRoom_Id }, classRoom);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(int id, ClassRoom classRoom)
        {
            if (id != classRoom.ClassRoom_Id)
            {
                return BadRequest();
            }

            if (_classRoomRepository.Update(classRoom))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            if (_classRoomRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}