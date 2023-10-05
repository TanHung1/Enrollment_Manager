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

        public bool Register(string email, string password);
        public bool Login(string email, string password);
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

        public bool Login(string email, string password)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (account != null)
            {
                return true;
            }
            return false;
        }

        public bool Register(string email, string password)
        {
            if (_dbContext.Accounts.Any(x => x.Email == email))
            {
                return false;
            }
            var account = new Account { Email = email, Password = password };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return true;
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
