using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class JobTaskRepository : GenericRepository<JobTask>, IJobTaskRepository
    {
        public JobTaskRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
        public override async Task<IEnumerable<JobTask>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Assignee).ToListAsync();
        }
        public async Task<IEnumerable<JobTask>> GetByVisitPlanId(int visitPlanId)
        {
            return await _dbSet.Where(x => x.VisitPlanId == visitPlanId).Include(x => x.Assignee).ToListAsync();
        }
        public override async Task<JobTask> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id).Include(x => x.Assignee).Include(x => x.Comments).ThenInclude(x => x.User).Include(x => x.CreatedBy).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<JobTask>> Search(string keyword)
        {
            return await _dbSet.Where(x => x.Title.Contains(keyword)).ToListAsync();
        }
    }
}
