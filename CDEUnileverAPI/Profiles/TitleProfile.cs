using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile() {
            CreateMap<TitleDTO, Title>()
                .ForMember(dest => dest.Name, frm => frm.MapFrom(x => x.Name))
                .ForMember(dest => dest.Description, frm => frm.MapFrom(x => x.Description));
        }
    }
}
