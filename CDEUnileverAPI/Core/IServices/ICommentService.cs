using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ICommentService
    {
        public Task<IEnumerable<Comment>> GetAllbyTask(int jobTaskId);
        public Task<bool> AddComment(Comment comment);
        public Task<bool> DeleteComment(int id);
    }
}
