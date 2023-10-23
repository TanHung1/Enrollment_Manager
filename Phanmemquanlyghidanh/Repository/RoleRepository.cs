using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface IRoleRepository
    {
        public bool Create(Role role);
        public bool Update(Role role);
        public bool Delete(int Id);
        public List<Role> GetAll();

        public List<Role> SearchByName(string name);
        public Role GetById(int id);
    }
    public class RoleRepository : IRoleRepository
    {
        private EnrollmentContext _dbContext;

        public RoleRepository(EnrollmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Role role = _dbContext.Roles.FirstOrDefault(x => x.RoleId == Id);
            _dbContext.Remove(role);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetById(int id)
        {
            Role role = _dbContext.Roles.FirstOrDefault(x => x.RoleId == id);
            return role;
        }

        public List<Role> SearchByName(string name)
        {
            return _dbContext.Roles.Where(x => x.RoleName.Contains(name)).ToList();
        }

        public bool Update(Role role)
        {
            Role r = _dbContext.Roles.FirstOrDefault(x => x.RoleId == role.RoleId);
            if (r != null)
            {
                _dbContext.Entry(r).CurrentValues.SetValues(role);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
