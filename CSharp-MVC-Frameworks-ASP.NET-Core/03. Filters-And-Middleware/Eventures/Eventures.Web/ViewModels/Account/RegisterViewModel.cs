using Eventures.Models;
using Eventures.Web.MappingConfigurations;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels.Account
{
    public class RegisterViewModel : IMapTo<EventureUser>
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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "UCN must be exactly 10 numbers.")]
        public string UniqueCitizenNumber { get; set; }
    }
}
