using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class CommentProfile :Profile
    {
        public CommentProfile()
        {
            CreateMap<ShowCommentListDTO,Comment>().ReverseMap();
            CreateMap<CommentDTO,Comment>().ReverseMap();

        }
    }
}
