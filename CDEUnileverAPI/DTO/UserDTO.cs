using CDEUnileverAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ReporterId { get; set; }
        public bool Status { get; set; } = true;
    }
    public class ChangePasswordUserDTO
    {
        [Required]
        public string NewPassword { get; set; }
    }
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
