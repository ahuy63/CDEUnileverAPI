using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetByAreaIdAsync(int areaId);
    }
}
