using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap
{
    public static class Setup
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddApplication();
            services.AddSwagger();
        }

        public static void UseSwaggerGTVe(this IApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
        }
    }
}