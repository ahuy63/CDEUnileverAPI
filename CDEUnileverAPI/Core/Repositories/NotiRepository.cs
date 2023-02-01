using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class NotiRepository : GenericRepository<Notification>, INotiRepository
    {
        public NotiRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
    }
}
