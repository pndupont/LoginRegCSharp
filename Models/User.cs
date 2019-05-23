using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LOGINREG.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength (2, ErrorMessage = "Minimum length for First Name is 2")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength (2, ErrorMessage = "Minimum length for Last Name is 2")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        // [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [NotMapped]
        [Compare("Password", ErrorMessage="Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
