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
            if (_checkOutRepository.CreateCheckOut(checkOut))
            {
                return CreatedAtAction(nameof(GetCheckOut), new { id = checkOut.CheckOut_Id }, checkOut);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCheckOut(int id, CheckOut checkOut)
        {
            if (id != checkOut.CheckOut_Id)
            {
                return BadRequest();
            }

            if (_checkOutRepository.UpdateCheckOut(checkOut))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCheckOut(int id)
        {
            if (_checkOutRepository.DeleteCheckOut(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}