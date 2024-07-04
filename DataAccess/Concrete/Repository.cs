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
            string[] includeArray = includeTables.Split('.');
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            foreach (var table in includeArray)
            {
                query = query.Include(table).Include(x => EF.Property<int>(x, "Brand"));
            }

            return query.FirstOrDefault(entity => EF.Property<int>(entity, "Id") == id);
        }

        public IQueryable<T> GetAll(string includeTables)
        {
            string[] includeArray = includeTables.Split('.');
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            foreach (var table in includeArray)
            {
                query = query.Include(table.Trim());
            }
            return query;
        }
    }
}
