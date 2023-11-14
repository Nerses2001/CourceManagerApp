using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(120, ErrorMessage = "Email length must be between {2} and {1} characters", MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password length must be between {2} and {1} characters", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "Confirm Password length must be between {2} and {1} characters", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name length must be between {2} and {1} characters", MinimumLength = 3)]
        [RegularExpression("^(?=.{1,50}$)[A-Z][a-z]+(?:[- ][A-Z][a-z]+)*$", ErrorMessage = "Valid Characters include (A-Z) (a-z) (' space -)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name length must be between {2} and {1} characters", MinimumLength = 3)]
        [RegularExpression("^(?=.{1,50}$)[A-Z][a-z]+(?:[- ][A-Z][a-z]+)*$", ErrorMessage = "Valid Characters include (A-Z) (a-z) (' space -)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [StringLength(10, ErrorMessage = "Zip Code length must be between {2} and {1} characters", MinimumLength = 1)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
        public RegisterModel(string email, string password, string confirmPassword, string firstName, string lastName, string phoneNumber, DateTime dateOfBirth, string address, string zipCode)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ConfirmPassword = confirmPassword;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.ZipCode = zipCode;
        }
    }
}
