using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserDTO, User>().ReverseMap()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(frm => frm.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(frm => frm.FullName))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(frm => frm.TitleId))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(frm => frm.AreaId))
                .ForMember(dest => dest.ReporterId, opt => opt.MapFrom(frm => frm.ReporterId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status));
        }
    }
}
