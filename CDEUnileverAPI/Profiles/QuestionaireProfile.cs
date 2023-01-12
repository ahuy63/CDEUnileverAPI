using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class QuestionaireProfile : Profile
    {
        public QuestionaireProfile() { 
            CreateMap<AddNewQuestionaireDTO, Questionaire>().ReverseMap();
            CreateMap<ShowAllQuestionaireDTO, Questionaire>().ReverseMap();
        }
    }
}
