using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class ShowAreaDTO
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int? DistributorQty { get; set; } = 0;
    }
    public class ShowAreaDetailDTO : ShowAreaDTO
    {
        public ICollection<User>? Users { get; set; }
        public ICollection<Distributor>? Distributors { get; set; }
    }
}
