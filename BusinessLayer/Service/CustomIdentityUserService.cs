using AutoMapper;
using BusinessLayer.IService;
using DataLayer.IRepository;
using Entity;
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
            if(user == null) 
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            var existingUser = _userRepository
                .GetByEmail(user.Email);


            if (existingUser == null)
            {
                var userEntity = _mapper.Map<CustomIdentityUser>(user);
                
                _userRepository.Add(userEntity);
            }
            else 
                throw new ("User already exists");

        }

        public async Task AddUserAsync(CustomIdentityUserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User can not be null");

            var existingUser = await _userRepository
                .GetByEmailAsync(user.Email);

            if(existingUser == null)
            {
                var userEntity = _mapper.Map<CustomIdentityUser>(user);
                await _userRepository.AddAsync(userEntity);
            }
            else 
                throw new("User already exists");

        }

        public async Task<ICollection<CustomIdentityUserDTO>> GetByAddressAsync(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address), "Address can not be null or empoty");

            var users = await _userRepository
                .GetByAddressAsync(address);
            
            return _mapper.Map<ICollection<CustomIdentityUserDTO>>(users);
        }

        public async Task<ICollection<CustomIdentityUserDTO>> GetByDateOfBirthAsync(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Now)
                throw new ArgumentException("Date of birth cannot be in the future", nameof(dateOfBirth));

            var users = await _userRepository
                .GetByDateOfBirthAsync(dateOfBirth);

            return _mapper.Map<ICollection<CustomIdentityUserDTO>>(users);

        }

        public async Task<ICollection<CustomIdentityUserDTO>> GetByLastNameAsync(string lName)
        {
            if (string.IsNullOrEmpty(lName))
                throw new ArgumentNullException(nameof(lName), "LastName can not be null or empoty");

            var users = await _userRepository
                .GetByLastNameAsync(lName);

            return _mapper.Map<ICollection<CustomIdentityUserDTO>>(users);

        }

        public async Task<ICollection<CustomIdentityUserDTO>> GetByNameAsync(string fName)
        {
            if (string.IsNullOrEmpty(fName))
                throw new ArgumentNullException(nameof(fName), "Name can not be null or empoty");

            var users = await _userRepository
                .GetByNameAsync(fName);

            return _mapper.Map<ICollection<CustomIdentityUserDTO>>(users);

        }

        public CustomIdentityUserDTO GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");

            var user = _userRepository
                .GetByEmail(email);

            if (user == null)
                throw new ArgumentNullException(nameof(user), "User not found by Email");

            return _mapper.Map<CustomIdentityUserDTO>(user);
        }

        public async Task<CustomIdentityUserDTO> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");

            var user = await _userRepository
                .GetByIdAsync(email);

            if(user == null) 
                throw new ArgumentNullException(nameof(user), "User not found by Email");


            return _mapper.Map<CustomIdentityUserDTO>(user);
        }

        public CustomIdentityUserDTO GetUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id), "Id cannot be null or empty");


            var user = _userRepository
                .GetById(id);
            
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User not found by Id");
           
            return _mapper.Map<CustomIdentityUserDTO>(user);
        }

        public async Task<CustomIdentityUserDTO> GetUserByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id), "Id cannot be null or empty");

            var user = await _userRepository
                .GetByIdAsync(id); 
            
            if( user == null)
                throw new ArgumentNullException(nameof(user), "User not found by Id");

            return _mapper.Map<CustomIdentityUserDTO>(user);

        }

        public CustomIdentityUserDTO GetUserByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "PhoneNumber cannot be null or empty");

            var user =  _userRepository
                .GetByPhoneNumber(phoneNumber);

            if (user == null)
                throw new ArgumentNullException(nameof(user), "User not found by phoneNumber");

            return _mapper.Map<CustomIdentityUserDTO>(user);
        }

        public async Task<CustomIdentityUserDTO> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "PhoneNumber cannot be null or empty");

            var user = await _userRepository
                .GetByPhoneNumberAsync(phoneNumber);

            if (user == null)
                throw new ArgumentNullException(nameof(user), "User not found by phoneNumber");

            return _mapper.Map<CustomIdentityUserDTO>(user);
        }

        public void RemoveUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");

            var existingUser = _userRepository
                .GetByEmail(email);

            if (existingUser != null)
                _userRepository.Remove(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by email");
            

        }

        public async Task RemoveUserByEmailRemoveAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");

            var existingUser = await _userRepository
                .GetByEmailAsync(email);

            if (existingUser != null)
                await _userRepository.RemoveAsync(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by email");


        }

        public void RemoveUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id), "Email cannot be null or empty");

            var existingUser =_userRepository
                .GetById(id);

            if (existingUser != null)
                 _userRepository.Remove(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by Id");


        }

        public async Task RemoveUserByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id), "Email cannot be null or empty");

            var existingUser = await _userRepository
                .GetByIdAsync(id);

            if (existingUser != null)
                await _userRepository.RemoveAsync(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by Id");
        }

        public void RemoveUserByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "PhoneNumber cannot be null or empty");

            var existingUser = _userRepository
                .GetByPhoneNumber(phoneNumber);

            if (existingUser != null)
                _userRepository.Remove(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by PhoneNumber");

        }

        public async Task RemoveUserByPhoneNumberRemoveAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "PhoneNumber cannot be null or empty");

            var existingUser = await _userRepository
                .GetByPhoneNumberAsync(phoneNumber);

            if (existingUser != null)
                await _userRepository.RemoveAsync(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found by PhoneNumber");

        }

        public void UpdateUser(CustomIdentityUserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            var existingUser = _userRepository
                .GetByEmail(user.Email);

            if (existingUser != null)
                _userRepository.Update(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found");

        }

        public async Task UpdateUserAsync(CustomIdentityUserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            var existingUser = await _userRepository
                .GetByEmailAsync(user.Email);

            if (existingUser != null)
                await _userRepository.UpdateAsync(existingUser);
            else
                throw new ArgumentNullException(nameof(existingUser), "User not found");
        }

        public Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
