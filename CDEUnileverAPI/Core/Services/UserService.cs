using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public async Task<IEnumerable<ShowUserListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShowUserListDTO>>( await _unitOfWork.UserRepository.GetAllAsync());
        }

        public async Task<UserDetailsDTO> GetUser(int id)
        {
            return _mapper.Map<UserDetailsDTO>( await _unitOfWork.UserRepository.GetById(id));
        }

        public Task<bool> AddUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetById(id);
                if (user != null)
                {
                    if (await _unitOfWork.UserRepository.Delete(user))
                    {
                        await _unitOfWork.CommitAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(int id, UpdateUserDTO userDto)
        {
            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetById(id);
                if (existingUser != null)
                {
                    existingUser.FullName = userDto.FullName;
                    existingUser.Phone = userDto.Phone;
                    existingUser.Address = userDto.Address;
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserPassword(int id, string newPassword)
        {
            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetById(id);
                if (existingUser != null)
                {
                    existingUser.Password = newPassword;
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
