using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
        public async Task<bool> AddUserToArea(int userId, int areaId)
        {
            try
            {
                var data = new Area_User();
                data.UserId = userId;
                data.AreaId = areaId;
                await _context.Areas_Users.AddAsync(data);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public async Task<bool> AddDistributorToArea(int distributorId, int areaId)
        {
            try
            {
                var data = new Area_Distributor();
                data.DistributorId = distributorId;
                data.AreaId = areaId;
                await _context.Areas_Distributors.AddAsync(data);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}

