using Microsoft.AspNetCore.Mvc;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;

namespace Phanmemquanlyghidanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAll();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var account = _accountRepository.GetAccountById(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST: api/Accounts
        [HttpPost]
        public ActionResult<Account> CreateAccount(Account account)
        {
            if (_accountRepository.CreateAccount(account))
            {
                return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
            }

            return BadRequest();
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            if (_accountRepository.UpdateAccount(account))
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            if (_accountRepository.DeleteAccount(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost("Login")]
        public IActionResult Login(Account account)
        {
            bool success = _accountRepository.Login(account.Email, account.Password);
            if (success)
            {
                return Ok("Thanh cong");
            }
            return BadRequest("Đăng nhập thất bại, tài khoản hoặc mật khẩu không đúng");
        }

        [HttpPost("Register")]
        public IActionResult Register(Account account)
        {
            bool register = _accountRepository.Register(account.Email, account.Password);
            if (register)
            {
                return Ok("Đăng ký thành công");

            }
            return BadRequest("Đăng ký thất bại, Email đã tồn tại");
        }
    }
}