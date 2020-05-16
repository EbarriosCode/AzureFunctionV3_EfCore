using AzureFunction_EFCore.DataContext;
using AzureFunction_EFCore.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(AzureFunction_EFCore.Startup))]
namespace AzureFunction_EFCore
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
            // Inicializar EF Core por Inyección de Dependencias
            builder.Services.AddDbContext<FunctionContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString")));

            // Inyección de depndencias de servicios personalizados
            builder.Services.AddTransient<IAlbumService, AlbumService>();
            builder.Services.AddTransient<IArtistaService, ArtistaService>();
        }
    }
}
