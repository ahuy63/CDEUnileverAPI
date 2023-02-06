using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.DTO
{
    public class SurveyDTO
    {
        public string Title { get; set; }
        public int QuestionnaireId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ParticipantDTO> Participants { get; set; }
    }
    public class SurveyListDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Thuchien { get; set; }
    }
    public class SurveyDetailDTO
    {
        public string Title { get; set; }
        public string QuestionnaireTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ParticipantDetailDTO> Participants { get; set; }
    }

    public class ParticipantDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class ParticipantLoginDTO
    {
        public string Email { get; set; }
    }
    public class ParticipantDetailDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<ShowSurveyAnswerDTO> Answers { get; set; }
    }
    public class SurveyAnswerDTO
    {
        public int QuestionId { get; set; }
        public bool AnswerA { get; set; } = false;
        public bool AnswerB { get; set; } = false;
        public bool AnswerC { get; set; } = false;
        public bool AnswerD { get; set; } = false;
        public bool AnswerE { get; set; } = false;
    }

    public class ShowSurveyAnswerDTO
    {
        public string Question { get; set; }
        public bool AnswerA { get; set; }
        public bool AnswerB { get; set; } 
        public bool AnswerC { get; set; }
        public bool AnswerD { get; set; } 
        public bool AnswerE { get; set; } 
    }

}
