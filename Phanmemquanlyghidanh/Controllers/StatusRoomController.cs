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

        [HttpPost]
        public IActionResult Create(StatusRoom statusRoom)
        {
            try
            {
                bool created = _statusRoomRepository.Create(statusRoom);
                if (created)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi phù hợp
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StatusRoom statusRoom)
        {
            try
            {
                statusRoom.StatusRoom_Id = id;
                bool updated = _statusRoomRepository.Update(statusRoom);
                if (updated)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi phù hợp
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _statusRoomRepository.Delete(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi phù hợp
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<StatusRoom> statusRooms = _statusRoomRepository.GetAll();
                return Ok(statusRooms);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi phù hợp
                return StatusCode(500, ex.Message);
            }
        }
    }
}