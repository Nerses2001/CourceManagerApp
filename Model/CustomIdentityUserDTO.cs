namespace Model
{
    public class CustomIdentityUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public CustomIdentityUserDTO
            (
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            string email, 
            string phoneNumber, 
            string address, 
            string zipCode
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.ZipCode = zipCode;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }
    }
}