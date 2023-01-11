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
    public class UserDetailsDTO
    {
        [Required]
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public User Reporter { get; set; }
    }
    public class ShowUserListDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string TitleName { get; set; }
        public string AreaName { get; set; }
        public string ReporterFullName { get; set; }
        public bool Status { get; set; } = true;

    }
    public class ShowArea_UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Title Title { get; set; }
    }
    public class UpdateUserDTO
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
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

    public class AddNewUserToAreaDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public int ReporterId { get; set; }
        public bool Status { get; set; } = true;
    }
}
