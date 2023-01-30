namespace CDEUnileverAPI.Models
{
    public class QuestionnaireDetail
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public int? QuestionnairePart { get; set; }
        public string Question { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? AnswerE { get; set; }
        public bool IsMultipleAns { get; set; } = false;
    }

}
