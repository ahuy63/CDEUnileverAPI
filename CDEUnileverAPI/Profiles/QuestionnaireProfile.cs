using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class QuestionnaireProfile : Profile
    {
        public QuestionnaireProfile() { 
            CreateMap<AddNewQuestionaireDTO, Questionnaire>().ReverseMap();
            CreateMap<ShowAllQuestionaireDTO, Questionnaire>().ReverseMap();
            CreateMap<AddNewQuestionDTO, QuestionnaireDetail>().ReverseMap();
            CreateMap<QuestionnaireDetailsDTO, Questionnaire>().ReverseMap();
                //.ForMember(dest => dest.Questions, opt => opt.MapFrom(frm => new ICollection<ShowQuestionDTO> { frm.Title}));
            CreateMap<QuestionnaireDetail, ShowQuestionDTO>().ReverseMap();
            
        }
    }
}
