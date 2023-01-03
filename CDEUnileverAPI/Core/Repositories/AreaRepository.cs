using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }

    }
}

