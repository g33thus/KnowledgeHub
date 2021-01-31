using Employee_Hub.Accessor;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.Engines;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers;
using Employee_Hub.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employee_Hub.Extensions
{
    public static class IoCConfigurationExtension
    {
        public static void ConfigureIoc(this IServiceCollection services)
        {
            services.ConfigureManagersIoc();
            services.ConfigureAccessorsIoc();
            services.ConfigureEngineIoc();
        }

        private static void ConfigureManagersIoc(this IServiceCollection services)
        {
            services.AddScoped<IArticleManager, ArticleManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ITagManager, TagManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserArticleManager, UserArticleManager>();
        }

        private static void ConfigureAccessorsIoc(this IServiceCollection services)
        {
            services.AddScoped<IArticleAccessor, ArticleAccessor>();
            services.AddScoped<ICategoryAccessor, CategoryAccessor>();
            services.AddScoped<ITagAccessor, TagAccessor>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IUserArticleAccessor, UserArticleAccessor>();
        }

        private static void ConfigureEngineIoc(this IServiceCollection services)
        {
            services.AddScoped<IArticleEngine, ArticleEngine>();
            services.AddScoped<ICategoryEngine, CategoryEngine>();
            services.AddScoped<ITagEngine, TagEngine>();
            services.AddScoped<IUserEngine, UserEngine>();
            services.AddScoped<IUserArticleEngine, UserArticleEngine>();
        }
    }
}
