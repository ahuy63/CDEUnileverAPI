namespace CDEUnileverAPI.Models
{
    public class Area_Distributor
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
    }
}
