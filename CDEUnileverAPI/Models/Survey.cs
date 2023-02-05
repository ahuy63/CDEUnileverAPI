namespace CDEUnileverAPI.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public ICollection<Survey_Participant> Participants { get; set; }
    }
}
