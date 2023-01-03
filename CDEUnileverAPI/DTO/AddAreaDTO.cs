using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class AddAreaDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
