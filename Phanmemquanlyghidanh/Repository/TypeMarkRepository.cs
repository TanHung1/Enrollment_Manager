using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ITypeMarkRepository
    {
        public List<TypeMark> GetMarkList();

        public bool Create(TypeMark typemark);
        public bool Delete(int id);
        public bool Update(TypeMark typemark);

        public TypeMark GetMarkId(int id);

        public List<TypeMark> SearchByName(string name);

    }
    public class TypeMarkRepository : ITypeMarkRepository
    {
        private EnrollmentContext _dbcontext;

        public TypeMarkRepository(EnrollmentContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Create(TypeMark typemark)
        {
            _dbcontext.TypeMarks.Add(typemark);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            TypeMark tm = _dbcontext.TypeMarks.FirstOrDefault(x => x.TypeID == id);
            _dbcontext.Remove(tm);
            _dbcontext.SaveChanges();
            return true;
        }

        public TypeMark GetMarkId(int id)
        {
            TypeMark tm = _dbcontext.TypeMarks.FirstOrDefault(x => x.TypeID == id);
            return tm;
        }



        public List<TypeMark> GetMarkList()
        {
            return _dbcontext.TypeMarks.ToList();
        }

        public List<TypeMark> SearchByName(string name)
        {
            return _dbcontext.TypeMarks.Where(x => x.TypeName.Contains(name)).ToList();
        }

        public bool Update(TypeMark typemark)
        {
            TypeMark tm = _dbcontext.TypeMarks.FirstOrDefault(x => x.TypeID == typemark.TypeID);
            if (tm != null)
            {
                _dbcontext.Entry(tm).CurrentValues.SetValues(typemark);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
