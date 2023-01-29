using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        //public string Title { get; set; } = "Khảo sát - " + DateTime.UtcNow.ToString("dd/MM");
        [Required]
        public string Title { get; set; }
        public bool Status { get; set; } = true;
        public int NumberOfQuestions { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<QuestionnaireDetail> Questions { get; set; }
    }
}
