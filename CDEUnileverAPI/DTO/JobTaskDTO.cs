namespace CDEUnileverAPI.DTO
{
    public class JobTaskDTO
    {
    }
    public class ShowJobTaskListDTO
    {
        public string Title { get; set; }
        public string AssigneeName { get; set; }
        public DateTime DateStart { get; set; }
        public string Status { get; set; }
    }
    public class ShowJobTaskDetailsDTO
    {
        public string Title { get; set; }
        public string AssigneeName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string CreatedByName { get; set; }
        public string Description { get; set; }
    }

}
