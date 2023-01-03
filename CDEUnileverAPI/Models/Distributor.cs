namespace CDEUnileverAPI.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SaleSupId { get; set; }
        public User SaleSup { get; set; }
    }
}
