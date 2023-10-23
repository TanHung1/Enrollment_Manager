using Microsoft.EntityFrameworkCore;
using Phanmemquanlyghidanh.Models;
using System.Security.Cryptography;
using System.Text;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();

        public bool CreateAccount(Account account);
        public bool UpdateAccount(Account account);
        public bool DeleteAccount(int Id);
        public Account GetAccountById(int id);

        public List<Account> Search(string search);
        public Task<Account> Register(Account account);

        public Task<Account> Login(string email, string password);

    }
    public class AccountRepository : IAccountRepository
    {
        private EnrollmentContext _dbContext;

        public AccountRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateAccount(Account account)
        {
            if (!account.Email.EndsWith("@gmail.com"))
            {
                account.Email += "@gmail.com";
            }
            string hashedPassword = HashPassword(account.Password);
            account.Password = hashedPassword;

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            //Kiểm tra xem SubjectId có được điền vào hay không
            if (account.ClassRoomId != null)
            {
                // Tăng giá trị currentStudent của lớp đó
                ClassRoom classRoom = _dbContext.ClassRooms.FirstOrDefault(c => c.ClassRoomId == account.ClassRoomId);
                if (classRoom != null)
                {
                    classRoom.CurrentStudent++;
                    _dbContext.SaveChanges();
                }
            }

            return true;
        }

        public bool DeleteAccount(int Id)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.AccountId == Id);
            if (acc != null)
            {
                int classRoomId = acc.ClassRoomId;
                _dbContext.Remove(acc);
                _dbContext.SaveChanges();

                ClassRoom classRoom = _dbContext.ClassRooms.FirstOrDefault(c => c.ClassRoomId == classRoomId);
                if (classRoom != null && classRoom.CurrentStudent > 0)
                {
                    classRoom.CurrentStudent--;
                    _dbContext.SaveChanges();
                }
            }

            return true;
        }

        public Account GetAccountById(int id)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.AccountId == id);
            return acc;
        }

        public List<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();

        }



        public async Task<Account> Login(string email, string password)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
            return account;
        }

        public async Task<Account> Register(Account account)
        {
            string hashedPassword = HashPassword(account.Password);
            account.Password = hashedPassword;
            //account.RoleId = 3;
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account;
        }

        public List<Account> Search(string search)
        {
            return _dbContext.Accounts.Where(x => x.LastName.Contains(search) ||
                                                  x.Email.Contains(search) ||
                                                  x.PhoneNumber.Contains(search)).ToList();
        }

        public bool UpdateAccount(Account account)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.AccountId == account.AccountId);
            if (acc != null)
            {
                _dbContext.Entry(acc).CurrentValues.SetValues(account);
                _dbContext.SaveChanges();
            }
            return true;
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
