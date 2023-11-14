using Model;

namespace BusinessLayer.IService
{
    public interface ICustomIdentityUserService
    {
        CustomIdentityUserDTO GetUserById(string id);
        Task<CustomIdentityUserDTO> GetUserByIdAsync(string id);
        CustomIdentityUserDTO GetUserByEmail(string email);
        Task<CustomIdentityUserDTO> GetUserByEmailAsync(string email);
        CustomIdentityUserDTO GetUserByPhoneNumber(string phoneNumber); 
        Task<CustomIdentityUserDTO> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<ICollection<CustomIdentityUserDTO>> GetByAddressAsync(string address);
        Task<ICollection<CustomIdentityUserDTO>> GetByNameAsync(string fName);
        Task<ICollection<CustomIdentityUserDTO>> GetByLastNameAsync(string lName);
        Task<ICollection<CustomIdentityUserDTO>> GetByDateOfBirthAsync(DateTime dateOfBirth);
        void AddUser(CustomIdentityUserDTO user);
        void RemoveUserByEmail(string email);
        void RemoveUserByPhoneNumber(string phoneNumber);
        void RemoveUserById(string id);
        void UpdateUser(CustomIdentityUserDTO user);
        Task AddUserAsync(CustomIdentityUserDTO user);
        Task UpdateUserAsync(CustomIdentityUserDTO user);
        Task RemoveUserByIdAsync(string id);
        Task RemoveUserByEmailRemoveAsync(string email);
        Task RemoveUserByPhoneNumberRemoveAsync(string phoneNumber);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
    }
}
