using System.Linq.Expressions;
using TeklifVer.Entities;

namespace DataAccess.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        public void Create(T t);
        public void Delete(T t);
        public void Update(T t);
        public T GetById(int id);
        public T GetByFilter(Expression<Func<T, bool>> filter);
        public List<T> GetByFilterList(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAll();
        public T GetById(int id, string includeTables);
        public IQueryable<T> GetAll(string includeTables);
    }
}
