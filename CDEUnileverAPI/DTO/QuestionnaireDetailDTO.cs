namespace CDEUnileverAPI.DTO
{
    public class QuestionnaireDetailDTO
    {
        public string Question { get; }
        public int? QuestionarePart { get; }
        public string? AnswerA { get; }
        public string? AnswerB { get; }
        public string? AnswerC { get; }
        public string? AnswerD { get; }
        public string? AnswerE { get; }
        public bool IsMultipleAns { get; }
    }
}
