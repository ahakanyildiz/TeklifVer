using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeklifVer.Entities;

namespace DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CarContext _context;

        public Repository(CarContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().SingleOrDefault(filter);
        }

        public List<T> GetByFilterList(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }


        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }




        public T GetById(int id, string includeTables)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!string.IsNullOrEmpty(includeTables))
            {
                var includeProperties = includeTables.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault(entity => EF.Property<int>(entity, "Id") == id);
        }

        public IQueryable<T> GetAll(string includeTables)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!string.IsNullOrEmpty(includeTables))
            {
                var includeProperties = includeTables.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }
    }
}
