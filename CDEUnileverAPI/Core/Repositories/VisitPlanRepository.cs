using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class VisitPlanRepository : GenericRepository<VisitPlan>, IVisitPlanRepository
    {
        public VisitPlanRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
        public async Task<IEnumerable<VisitPlan>> Search(string keyword)
        {
            return await _dbSet.Where(x => x.Name.Contains(keyword)).ToListAsync();
        }   

    }
}
    