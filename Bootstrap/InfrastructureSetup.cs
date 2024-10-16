using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bootstrap
{
    internal static class InfrastructureSetup
    {
        internal static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMessagesHandler, MessagesHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //ConfigureHealthCheck(services, configuration);
        }

        internal static void AddInfrastructureFilter(this MvcOptions options)
        {
            //options.Filters.Add<AuthenticationFilter>();
        }

        internal static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            //app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            //app.UseHealthChecksUI();
        }

        private static void ConfigureHealthCheck(IServiceCollection services, IConfiguration configuration)
        {
            //var healthChecksApp = new List<HealthChecksApp>();

            //new ConfigureFromConfigurationOptions<List<HealthChecksApp>>
            //(
            //    configuration.GetSection("HealthChecksApp")
            //).Configure(healthChecksApp);
            //healthChecksApp = healthChecksApp.OrderBy(d => d.Name).ToList();
            //services.AddHealthChecks().AddDependencies(healthChecksApp, configuration);
            //services.AddHealthChecksUI();
        }
    }
}