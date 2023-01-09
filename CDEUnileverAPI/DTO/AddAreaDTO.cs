using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class AddAreaDTO
    {
        [Required]
        public string Name { get; set; }
    }
    public class Area_UserDTO
    {
        public int UserId { get; set; }
        public int AreaId { get; set; }
    }
    public class Area_DistributorDTO
    {
        public int DistributorId { get; set; }
        public int AreaId { get; set; }
    }
}
