using Data.Context;
using Data.Repository.Implementation;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace IoC
{
    public class ComponentRegistrar
    {
        public static void InitComponent(IServiceCollection services)
        {
            //Context
            services.AddScoped(typeof(CoffeeRenoContext), typeof(CoffeeRenoContext));

            //Repository
            RegRepository(services);

            //Service
            RegServices(services);

            //Common
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IUserLoginHistoryRepository), typeof(UserLoginHistoryRepository));
            services.AddScoped(typeof(IUserProfileRepository), typeof(UserProfileRepository));
            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IAdsFormRepository), typeof(AdsFormRepository));
            services.AddScoped(typeof(IAdsTypeRepository), typeof(AdsTypeRepository));
            services.AddScoped(typeof(IApplicationLanguageRepository), typeof(ApplicationLanguageRepository));
            services.AddScoped(typeof(IImageRepository), typeof(ImageRepository));
            services.AddScoped(typeof(IPostRepository), typeof(IPostRepository));
            services.AddScoped(typeof(IPostRepository), typeof(IPostRepository));
            services.AddScoped(typeof(IPostImageRepository), typeof(PostImageRepository));
            services.AddScoped(typeof(IPostTypeRepository), typeof(PostTypeRepository));
        }
        private static void RegServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAdminServices), typeof(AdminServices));
            services.AddScoped(typeof(IAccountManagerService), typeof(AccountManagerService));
        }
    }
}
