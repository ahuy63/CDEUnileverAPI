using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class VisitPlanRepository : GenericRepository<VisitPlan>, IVisitPlanRepository
    {
        public VisitPlanRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
    }
}
