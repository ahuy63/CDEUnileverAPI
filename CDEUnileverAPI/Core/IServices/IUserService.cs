using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<ApiResponse> AddUser(User user);
        public Task<User> GetUser(int id);
        public Task<IEnumerable<User>> GetUserByAreaId(int areaId);
        public Task<User> GetUserDetails(int id);
        public Task<bool> DeleteUser(int id);
        public Task<bool> UpdateUser(int id, User user);
        public Task<bool> UpdateUserPassword(int id, string password);
        public Task<bool> UpdateUserArea(User user, int? areaId);
    }
}
