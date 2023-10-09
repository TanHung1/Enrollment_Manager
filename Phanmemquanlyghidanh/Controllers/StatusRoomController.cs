using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusRoomController : ControllerBase
    {
        private readonly IStatusRoomRepository _statusRoomRepository;

        public StatusRoomController(IStatusRoomRepository statusRoomRepository)
        {
            _statusRoomRepository = statusRoomRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var getall = _statusRoomRepository.GetAll();
            return Ok(getall);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var statusId = _statusRoomRepository.GetById(id);
            if (statusId == null)
            {
                return NotFound("Không tim thây Id");
            }
            return Ok(statusId);
        }
        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var SearchResults = _statusRoomRepository.SearchByName(name);
            if (!SearchResults.Any())
            {
                return NotFound("Không tìm thấy loại điểm");
            }
            return Ok(SearchResults);
        }
        [HttpPost]
        public IActionResult Create(StatusRoom statusRoom)
        {
            if (ModelState.IsValid)
            {
                _statusRoomRepository.Create(statusRoom);
                return Ok("Tạo thành công");

            }
            return BadRequest("Tạo thất bại");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StatusRoom statusRoom)
        {
            statusRoom.StatusRoom_Id = id;
            var resutl = _statusRoomRepository.Update(statusRoom);
            if (resutl)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _statusRoomRepository.GetById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id");
            }
            var delete = _statusRoomRepository.Delete(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }


    }
}