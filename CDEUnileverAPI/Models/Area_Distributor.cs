namespace CDEUnileverAPI.Models
{
    public class Area_Distributor
    {
        public int Id { get; set; }
        public int Id_Area { get; set; }
        public Area Area { get; set; }
        public int Id_Distributor { get; set; }
        public Distributor Distributors { get; set; }
    }
}
