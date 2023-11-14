using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RegisterModel
    {
        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression("^(?=.{1,50}$)[A-Z][a-z]+(?:[- ][A-Z][a-z]+)*$", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression("^(?=.{1,50}$)[A-Z][a-z]+(?:[- ][A-Z][a-z]+)*$", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
        public string LastName { get; set; }

        public RegisterModel(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ConfirmPassword = confirmPassword;
        }
    }
}
