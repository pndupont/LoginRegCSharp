using System.ComponentModel.DataAnnotations;

namespace LOGINREG.Models
{
    public class LoginUser
    {
    [Required(ErrorMessage = "email is required")]
    [EmailAddress]
    [Display (Name = "Email")]
    public string LoginEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display (Name = "Password")]
    public string LoginPassword { get; set; }
    }
}
