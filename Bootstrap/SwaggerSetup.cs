using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

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

        internal static void ConfigureSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwagger(s =>
            {
                s.PreSerializeFilters.Add((document, request) =>
                {
                    var path = request.Headers.TryGetValue("X-Original-URI", out Microsoft.Extensions.Primitives.StringValues value) 
                        ? value.FirstOrDefault() 
                        : string.Empty;

                    document.Servers = string.IsNullOrEmpty(path)
                        ? [new OpenApiServer { Url = $"{request.Scheme}://{request.Host.Value}" }]
                        : new List<OpenApiServer> { new() { Url = path.Split(new[] { "/swagger" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() } };
                });
            });

            builder.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("./v1/swagger.json", "v1");
                s.DocumentTitle = "Documentation";
                s.DocExpansion(DocExpansion.None);
            });
        }
    }
}