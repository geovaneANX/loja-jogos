using Application.Commands;
using Application.Handlers;
using Application.Services;
using Application.Services.Interface;
using Application.UseCases;
using Application.UseCases.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap
{
    internal static class ApplicationSetup
    {
        internal static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<PedidosCommand, bool>, PedidosHandler>();
            services.AddScoped<IPedidosUseCase, PedidosUseCase>(); 
            services.AddScoped<IPedidosService, PedidosService>();
        }
    }
}