using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(CDEUnileverDbContext _context, ILogger logger) :base(_context, logger)
        {

        }
    }
}
