using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface INotiRepository : IGenericRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetAllByUser(int userId);
    }
}
