using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class CustomIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public override string? Email { get; set; }

        public override string? PhoneNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public CustomIdentityUser(string firstName, string lastName, DateTime dateOfBirth, string address, string zipCode, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.ZipCode = zipCode;
            this.PhoneNumber = phoneNumber;
        }




    }
}