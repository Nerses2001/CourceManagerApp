using Entity;

namespace DataLayer.IRepository
{
    public interface ICustomIdentityUserRepository : IRepositoryBase<CustomIdentityUser>
    {
        CustomIdentityUser GetById(string id);
        Task<CustomIdentityUser> GetByIdAsync(string id);
        
        CustomIdentityUser GetByEmail(string email);
        Task<CustomIdentityUser> GetByEmailAsync(string email);
        
        CustomIdentityUser GetByPhoneNumber(string phoneNumber);
        Task<CustomIdentityUser> GetByPhoneNumberAsync(string phoneNumber);

        Task<ICollection<CustomIdentityUser>> GetByAddressAsync(string address);
        Task<ICollection<CustomIdentityUser>> GetByNameAsync(string fName);
        Task<ICollection<CustomIdentityUser>> GetByLastNameAsync(string lName);
        Task<ICollection<CustomIdentityUser>> GetByDateOfBirthAsync(DateTime dateOfBirth);

       
        
    }
}
