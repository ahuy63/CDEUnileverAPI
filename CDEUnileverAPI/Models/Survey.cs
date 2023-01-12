namespace CDEUnileverAPI.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionareId { get; set; }
        public Questionaire Questionare { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<User> Participants { get; set; }
        public int Completed { get; set; } = 0;
    }
}
