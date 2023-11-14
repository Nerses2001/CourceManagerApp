using AutoMapper;
using BusinessLayer.IService;
using DataLayer.IRepository;
using Model;

namespace BusinessLayer.Service
{
    public class CustomIdentityUserService : ICustomIdentityUserService
    {
        private readonly IMapper _mapper;
        private readonly ICustomIdentityUserRepository _userRepository;

        public CustomIdentityUserService(ICustomIdentityUserRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            _userRepository = repository;
        }

        public void AddUser(CustomIdentityUserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task AddUserAsync(CustomIdentityUserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomIdentityUserDTO>> GetByAddressAsync(string address)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomIdentityUserDTO>> GetByDateOfBirthAsync(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomIdentityUserDTO>> GetByLastNameAsync(string lName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomIdentityUserDTO>> GetByNameAsync(string fName)
        {
            throw new NotImplementedException();
        }

        public CustomIdentityUserDTO GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUserDTO> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public CustomIdentityUserDTO GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUserDTO> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public CustomIdentityUserDTO GetUserByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUserDTO> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserByEmailRemoveAsync(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserByPhoneNumberRemoveAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(CustomIdentityUserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(CustomIdentityUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
