namespace CDEUnileverAPI.Models
{
    public class SurveyAnswer
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public Survey_Participant Participant { get; set; }
        public int QuestionId { get; set; }
        public QuestionnaireDetail Question { get; set; }
        public bool AnswerA { get; set; } = false;
        public bool AnswerB { get; set; } = false;
        public bool AnswerC { get; set; } = false;
        public bool AnswerD { get; set; } = false;
        public bool AnswerE { get; set; } = false;
    }
}
