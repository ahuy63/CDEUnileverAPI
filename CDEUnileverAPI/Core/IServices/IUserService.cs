using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<ShowUserListDTO>> GetAll();
        public Task<bool> AddUser(UserDTO user);
        public Task<UserDetailsDTO> GetUser(int id);
        public Task<bool> DeleteUser(int id);
        public Task<bool> UpdateUser(int id, UpdateUserDTO user);
        public Task<bool> UpdateUserPassword(int id, string password);
    }
}
