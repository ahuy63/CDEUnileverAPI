using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IDistributorService
    {
        public Task<IEnumerable<Distributor>> GetAll();
        public Task<bool> AddDistributor(DistributorDTO distributor);
        public Task<Distributor> GetDistributor(int id);
        public Task<bool> DeleteDistributor(int id);
        public Task<bool> UpdateDistributor(int id, DistributorDTO distributor);
    }
}
