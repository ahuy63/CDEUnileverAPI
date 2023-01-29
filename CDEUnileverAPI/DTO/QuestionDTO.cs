using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.DTO
{
    public class QuestionDTO
    {
    }
    public class AddNewQuestionDTO
    {
        public string Question { get; set; }
        public int? QuestionarePart { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? AnswerE { get; set; }
        public bool IsMultipleAns { get; set; } = false;
    }
    public class ShowQuestionDTO
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
