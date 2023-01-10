using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IDistributorRepository : IGenericRepository<Distributor>
    {
        Task<IEnumerable<Distributor>> GetByAreaIdAsync(int areaId);
    }
}
