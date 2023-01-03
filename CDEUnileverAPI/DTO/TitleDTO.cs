using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class TitleDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
