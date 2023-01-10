using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class DistributorDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int SaleSupId { get; set; }
        [Required]
        public int AreaId { get; set; }
    }
    public class ShowArea_DistributorDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
