using Phanmemquanlyghidanh.Models;

namespace Phanmemquanlyghidanh.Repository
{
    public interface ITypeMarkRepository
    {
        public List<TypeMark> GetMarkList();

        public bool Create(TypeMark typemark);
        public bool Delete(int id);
        public bool Update(TypeMark typemark);


    }
    public class TypeMarkRepository : ITypeMarkRepository
    {
        private EnrollmentDBContext _dbcontext;

        public TypeMarkRepository(EnrollmentDBContext dbcontext)
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



        public List<TypeMark> GetMarkList()
        {
            return _dbcontext.TypeMarks.ToList();
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
