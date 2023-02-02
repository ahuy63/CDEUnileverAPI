using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class NotiProfile : Profile
    {
        public NotiProfile()
        {
            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<ShowNotiListDTO, Notification>().ReverseMap();
        }
    }
}
