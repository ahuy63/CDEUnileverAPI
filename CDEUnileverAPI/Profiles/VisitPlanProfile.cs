using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class VisitPlanProfile : Profile
    {
        public VisitPlanProfile()
        {
            CreateMap<VisitPlan, VisitPlanDTO>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(frm => frm.Name))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(frm => frm.Time))
                .ForMember(dest => dest.DistributorId, opt => opt.MapFrom(frm => frm.DistributorId))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(frm => frm.Purpose))
                .ForMember(dest => dest.GuestId, opt => opt.MapFrom(frm => frm.GuestId))
                ;
            CreateMap<VisitPlan, ShowVisitPlanListDTO>().ReverseMap();
            CreateMap<VisitPlan, VisitPlanDetailDTO>().ReverseMap();
        }
    }
}
