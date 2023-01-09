using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        Task<bool> AddUserToArea(int userId, int areaId);
        Task<bool> AddDistributorToArea(int distributorId, int areaId);
    }

}
