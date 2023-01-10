using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class DistributorProfile : Profile
    {
        public DistributorProfile()
        {
            CreateMap<DistributorDTO, Distributor>().ReverseMap();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //.ForMember(dest => dest.SaleSupId, opt => opt.MapFrom(src => src.SaleSupId))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            CreateMap<ShowArea_DistributorDTO, Distributor>().ReverseMap();
        }
    }
}
