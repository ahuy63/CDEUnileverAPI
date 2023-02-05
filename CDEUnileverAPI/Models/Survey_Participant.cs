namespace CDEUnileverAPI.Models
{
    public class Survey_Participant
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set;}
        public bool IsCompleted { get; set; } = false;

        public ICollection<SurveyAnswer>? Answers { get; set; }
        
    }
}
