using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap
{
    internal static class RepositorySetup
    {
        internal static void AddRepository(this IServiceCollection services)
        {
            //services.AddTransient<IConnectionSql, ConnectionSql>();
            //services.AddTransient<IGTVERepository, GTVERepository>();
        }
    }
}