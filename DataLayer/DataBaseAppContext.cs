using Entity;
using Entity.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataBaseAppContext : IdentityDbContext<CustomIdentityUser>
    {
        public DataBaseAppContext(DbContextOptions<DataBaseAppContext> options)
            : base(options)
        {
         //   Users = Set<CustomIdentityUser>(); 
        }

        //    public DbSet<CustomIdentityUser> Users { get; set; }
   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomIdentityUserConfiguration());

        }

    }
}