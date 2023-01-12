namespace CDEUnileverAPI.Models
{
    public class QuestionaireDetail
    {
        public int Id { get; set; }
        public int QuestionareId { get; set; }
        public Questionaire Questionaire { get; set; }
        public int? QuestionarePart { get; set; }
        public string Question { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? AnswerE { get; set; }
        public bool IsMultipleAns { get; set; } = false;
    }
}
