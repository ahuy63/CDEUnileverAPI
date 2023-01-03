using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile() {
            CreateMap<Area, ShowAreaDTO>().ReverseMap()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(frm => frm.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(frm => "CODx"))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(frm => frm.Name))
                .ForMember(dest => dest.DistributorQty, opt => opt.MapFrom(frm => frm.DistributorQty));
        }
    }
}
