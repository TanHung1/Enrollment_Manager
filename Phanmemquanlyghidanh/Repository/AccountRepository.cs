using Microsoft.EntityFrameworkCore;
using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();

        public bool CreateAccount(Account account);
        public bool UpdateAccount(Account account);
        public bool DeleteAccount(int Id);
        public Account GetAccountById(int id);

        public List<Account> SearchByName(string name);
        public Task<Account> Register(Account account);

        public Task<Account> Login(string email, string password);

    }
    public class AccountRepository : IAccountRepository
    {
        private EnrollmentDBContext _dbContext;

        public AccountRepository(EnrollmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAccount(int Id)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.Id == Id);
            _dbContext.Remove(acc);
            _dbContext.SaveChanges();
            return true;
        }

        public Account GetAccountById(int id)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);
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
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account;
        }

        public List<Account> SearchByName(string name)
        {
            return _dbContext.Accounts.Where(x => x.LastName.Contains(name)).ToList();
        }

        public bool UpdateAccount(Account account)
        {
            Account acc = _dbContext.Accounts.FirstOrDefault(x => x.Id == account.Id);
            if (acc != null)
            {
                _dbContext.Entry(acc).CurrentValues.SetValues(account);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
