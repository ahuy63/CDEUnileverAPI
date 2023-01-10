using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class DistributorRepository : GenericRepository<Distributor>, IDistributorRepository
    {
        public DistributorRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger) {
        }

        public async Task<IEnumerable<Distributor>> GetByAreaIdAsync(int areaId)
        {
            var a = _context.Set<Distributor>();
            return await a.Where(x => x.AreaId == areaId).ToListAsync();
        }
    }
}
