using DataLayer.IRepository;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class CustomIdentityUserRepository : 
        RepositoryBase<CustomIdentityUser>, 
        ICustomIdentityUserRepository
    {
        public CustomIdentityUserRepository(DataBaseAppContext baseContext):
            base(baseContext) {}

        public async Task<ICollection<CustomIdentityUser>> GetByAddressAsync(string address)
        {
            var users = await _context.Users
                .Where(u => u.Address == address)
                .ToListAsync();

            return users;
        }

        public async Task<ICollection<CustomIdentityUser>> GetByDateOfBirthAsync(DateTime dateOfBirth)
        {
            var users = await _context.Users
                .Where(u => u.DateOfBirth == dateOfBirth)
                .ToListAsync();
            
            return users;
        }

        public CustomIdentityUser GetByEmail(string email)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email);
            
            return user ?? throw new(nameof(user));
        }

        public async Task<CustomIdentityUser> GetByEmailAsync(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            
            return user ?? throw new(nameof(user));
        }

        public CustomIdentityUser GetById(string id)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == id);
            
            return user ?? throw new(nameof(user));
        }

        public async Task<CustomIdentityUser> GetByIdAsync(string id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            
            return user ?? throw new(nameof(user));
        }

        public async Task<ICollection<CustomIdentityUser>> GetByLastNameAsync(string lName)
        {
            var users = await _context.Users
                .Where(u => u.LastName == lName)
                .ToListAsync();

            return users;
        }

        public async Task<ICollection<CustomIdentityUser>> GetByNameAsync(string fName)
        {
            var users = await _context.Users
                .Where(u=> u.FirstName == fName)
                .ToListAsync();

            return users;
        }

        public CustomIdentityUser GetByPhoneNumber(string phoneNumber)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            
            return user ?? throw new(nameof(user));
        }

        public async Task<CustomIdentityUser> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            
            return user ?? throw new(nameof(user));
        }
    }
}
