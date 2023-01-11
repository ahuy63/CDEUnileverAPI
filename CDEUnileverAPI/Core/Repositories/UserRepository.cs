using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        { }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.Include(user => user.Title).Include(user => user.Area).ToListAsync();
        }
        public override async Task<User> GetById(int id)
        {
            return await _dbSet.Where(user => user.Id == id).Include(user => user.Title).Include(user => user.Area).Include(user => user.Reporter).FirstOrDefaultAsync();
        }
        public async Task<User> GetByEmail(string email) => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        public async Task<IEnumerable<User>> GetByAreaIdAsync(int areaId)
        {
            var a = _context.Set<User>();
            return await _dbSet.Include(user => user.Title).Where(x => x.AreaId == areaId).ToListAsync();
        }
    }
}

