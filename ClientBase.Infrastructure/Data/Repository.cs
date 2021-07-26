using ClientBase.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBase.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase<long>
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Get(long id)
        {
            return _dbSet.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(long id)
        {
            var entity = _dbSet.Where(t => t.Id == id).FirstOrDefault();
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
