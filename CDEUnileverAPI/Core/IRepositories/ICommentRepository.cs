using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<int> GetNumberOFRating(int jobTaskId);
        Task<double> GetSumRating(int jobTaskId);
        Task<IEnumerable<Comment>> GetAllbyTask(int jobTaskId);
    }
}
