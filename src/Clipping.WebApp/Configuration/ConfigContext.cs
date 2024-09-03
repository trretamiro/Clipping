using Microsoft.EntityFrameworkCore;
using Clipping.Data.Contexto;

namespace Clipping.WebApp.Configuration
{
    public static class ConfigContext
    {
        public static WebApplicationBuilder AddContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ClippingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ClippingDbContext"));
            });

            return builder;
        }
    }

}
