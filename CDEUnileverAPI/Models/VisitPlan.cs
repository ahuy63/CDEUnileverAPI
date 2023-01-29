namespace CDEUnileverAPI.Models
{
    public class VisitPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        public string Purpose { get; set; }
        public int? GuestId { get; set; }
        public User? Guest { get; set; }

        public ICollection<JobTask> Tasks { get; set; }

    }
}
