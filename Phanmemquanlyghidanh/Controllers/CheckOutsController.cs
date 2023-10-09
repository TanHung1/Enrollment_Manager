using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckOutsController : ControllerBase
    {
        private readonly ICheckOutRepository _checkOutRepository;

        public CheckOutsController(ICheckOutRepository checkOutRepository)
        {
            _checkOutRepository = checkOutRepository;
        }

        [HttpGet]
        public IEnumerable<CheckOut> GetCheckOuts()
        {
            return _checkOutRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CheckOut> GetCheckOut(int id)
        {
            var checkOut = _checkOutRepository.GetCheckOutById(id);

            if (checkOut == null)
            {
                return NotFound();
            }

            return checkOut;
        }

        [HttpPost]
        public ActionResult<CheckOut> CreateCheckOut(CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                _checkOutRepository.CreateCheckOut(checkOut);
                return Ok("Tạo thành công");
            }
            return BadRequest("Tạo thất bại");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCheckOut(int id, CheckOut checkOut)
        {
            checkOut.CheckOut_Id = id;
            var result = _checkOutRepository.UpdateCheckOut(checkOut);
            if (result)
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCheckOut(int id)
        {
            var result = _checkOutRepository.GetCheckOutById(id);
            if (result == null)
            {
                return NotFound("Không tìm thấy Id cần xóa");
            }
            var delete = _checkOutRepository.DeleteCheckOut(id);
            if (delete)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }
    }
}