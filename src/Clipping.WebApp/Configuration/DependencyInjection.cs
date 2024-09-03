using Clipping.Business.Interfaces;
using Clipping.Business.Services;
using Clipping.Data.Repository;
using Clipping.Domain.Interfaces;

namespace Clipping.WebApp.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ITagAppService, TagAppService>();            
            services.AddScoped<INoticiaAppService, NoticiaAppService>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<INoticiaRepository, NoticiaRepository>();

        }
    }
}
