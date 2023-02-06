using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class CommentProfile :Profile
    {
        public CommentProfile()
        {
            CreateMap<ShowCommentListDTO,Comment>().ReverseMap()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(frm => frm.User.FullName));
            CreateMap<CommentDTO,Comment>().ReverseMap();

        }
    }
}
