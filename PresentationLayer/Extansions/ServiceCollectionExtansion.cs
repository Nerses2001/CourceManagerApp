using AutoMapper;
using DataLayer;
using Entity;
using Microsoft.AspNetCore.Identity;
using Model.Mapper;

namespace PresentationLayer.Extansions
{
    public static class ServiceCollectionExtansion
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(

                mc =>
                {
                    mc.AddProfile(new CustomIdentityUserProfile());
                }
            );

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }
        public static IServiceCollection AddIdentityServer(this IServiceCollection services)
        {
            services.AddIdentity<CustomIdentityUser, IdentityRole>
                (c =>
                {
                    c.Password.RequireDigit = true;
                    c.Password.RequireLowercase = true;
                    c.Password.RequiredLength = 8;
                    c.Password.RequireNonAlphanumeric = true;
                    c.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<DataBaseAppContext>()
                .AddSignInManager<SignInManager<CustomIdentityUser>>()
                .AddDefaultTokenProviders();

            return services;

        }
    }
}
