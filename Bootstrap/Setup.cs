using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
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
            //services.AddRepository();
            services.AddSwagger();
        }

        public static void RegisterFilters(this MvcOptions options)
        {
            options.AddInfrastructureFilter();
        }

        public static void UseSwaggerGTVe(this IApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
        }

        public static void Configure(this IApplicationBuilder app)
        {
            //app.ConfigureHealthCheck();
        }
    }
}