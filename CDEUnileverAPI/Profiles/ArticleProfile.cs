using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO, Article>().ReverseMap();
            CreateMap<ShowArticleListDTO, Article>().ReverseMap()
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(frm => frm.CreatedBy.FullName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status ? (frm.IsPublished ? "Published" : "Unpublished") : "Disable"));
            CreateMap<UpdateArticleDTO, Article>().ReverseMap();
            CreateMap<ArticleDetailDTO, Article>().ReverseMap()
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(frm => frm.CreatedBy.FullName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status ? (frm.IsPublished ? "Published" : "Unpublished") : "Disable"));

        }
    }
}
