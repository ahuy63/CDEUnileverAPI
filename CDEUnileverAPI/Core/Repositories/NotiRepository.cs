using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class NotiRepository : GenericRepository<Notification>, INotiRepository
    {
        public NotiRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }

        public async Task<IEnumerable<Notification>> GetAllByUser(int userId)
        {
            return await _dbSet.Where(x => x.UserId == userId).Include(x => x.Sender).ToListAsync();
        }

        public override async Task<Notification> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id).Include(x => x.Sender).FirstOrDefaultAsync();
        }
    }
}
