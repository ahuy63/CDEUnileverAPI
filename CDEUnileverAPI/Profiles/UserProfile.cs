using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserDTO, User>();
        }
    }
}
