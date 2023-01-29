using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class JobTaskRepository : GenericRepository<JobTask>, IJobTaskRepository
    {
        public JobTaskRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
    }
}
