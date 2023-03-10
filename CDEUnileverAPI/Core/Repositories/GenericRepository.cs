using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CDEUnileverDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(CDEUnileverDbContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        } 
        public virtual async Task<T> GetById(int id) => await _dbSet.FindAsync(id);
        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        //public virtual async Task<IEnumerable<T>> Search(string keyword) => await _dbSet.Where(x => x.Equals(keyword)).ToListAsync();
    }
}
