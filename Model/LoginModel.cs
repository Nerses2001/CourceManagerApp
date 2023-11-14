using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class LoginModel
    {
        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        public LoginModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
