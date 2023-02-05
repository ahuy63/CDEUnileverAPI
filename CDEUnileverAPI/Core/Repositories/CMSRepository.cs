using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class CMSRepository : GenericRepository<Article>, ICMSRepository
    {
        public CMSRepository(CDEUnileverDbContext _context, ILogger logger) : base (_context, logger)
        {
        }
        public override async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.CreatedBy).ToListAsync();
        }
        public override async Task<Article> GetById(int id)
        {
            return await _dbSet.Include(x => x.CreatedBy).SingleOrDefaultAsync(x => x.Id == id);    
        }
    }
}
