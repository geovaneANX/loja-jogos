using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Bootstrap
{
    internal static class SwaggerSetup
    {
        internal static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Loja Manoel",
                    Version = "v1",
                    Description = "Jogos Online - Cálculo de Caixas",
                    Contact = new OpenApiContact
                    {
                        Name = "Geovane Silva",
                        Email = "geovane_an@outlook.com",
                        Url = new Uri("https://www.linkedin.com/in/geovane-anx/")
                    }
                });
            });
        }
    }
}