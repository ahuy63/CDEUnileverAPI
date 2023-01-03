using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(CDEUnileverDbContext _context, ILogger logger) :base(_context, logger)
        {

        }
    }
}
