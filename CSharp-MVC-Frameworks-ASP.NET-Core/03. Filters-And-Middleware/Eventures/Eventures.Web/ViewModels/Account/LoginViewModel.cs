using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [MinLength(3, ErrorMessage = "Username should be at least 3 characters long.")]
        [RegularExpression(@"^[0-9a-zA-Z_\-\*\.\~]+$", ErrorMessage = "Username should only contain alphanumeric characters, dashes, underscores, dots, asterisks and tildes.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be at least 5 characters long.", MinimumLength = 5)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
