using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusCheckOutController : ControllerBase
    {
        private IStatusCheckOutRepository _statusCheckOutRepository;

        public StatusCheckOutController(IStatusCheckOutRepository statusCheckOutRepository)
        {
            _statusCheckOutRepository = statusCheckOutRepository;
        }

        [HttpGet]
        public IEnumerable<StatusCheckOut> GetStatusCheckOuts()
        {
            return _statusCheckOutRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<StatusCheckOut> GetStatusCheckOut(int id)
        {
            var checkOut = _statusCheckOutRepository.GetStatusCheckOutById(id);

            if (checkOut == null)
            {
                return NotFound();
            }

            return checkOut;
        }

        [HttpPost]
        public ActionResult<StatusCheckOut> CreateStatusCheckOut(StatusCheckOut statusCheckOut)
        {
            if (ModelState.IsValid)
            {
                _statusCheckOutRepository.CreateStatusCheckOut(statusCheckOut);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatusCheckOut(int id, StatusCheckOut statusCheckOut)
        {
            statusCheckOut.StatusCheckOutId = id;
            var result = _statusCheckOutRepository.UpdateStatusCheckOut(statusCheckOut);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatusCheckOut(int id)
        {
            var result = _statusCheckOutRepository.GetStatusCheckOutById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _statusCheckOutRepository.DeleteStatusCheckOut(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }
    }
}