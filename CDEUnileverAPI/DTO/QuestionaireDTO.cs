using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
   
    public class QuestionaireDTO
    {
    }
    public class AddNewQuestionaireDTO
    {
        [Required]
        public string Title { get; set; }
    }
    public class ShowAllQuestionaireDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class QuestionnaireDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public ICollection<QuestionnaireDetail> Questions { get; set; }
    }
}
