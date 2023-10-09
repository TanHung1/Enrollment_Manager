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
                return NotFound("Không có phòng học cần tìm");
            }

            return classRoom;
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _classRoomRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public ActionResult<ClassRoom> CreateClassRoom(ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                _classRoomRepository.Create(classRoom);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(int id, ClassRoom classRoom)
        {
            classRoom.ClassRoom_Id = id;
            var result = _classRoomRepository.Update(classRoom);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            var result = _classRoomRepository.GetClassRoom(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _classRoomRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
    }
}