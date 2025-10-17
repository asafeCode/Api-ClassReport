using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Infrastructure.Clients;
using MyRecipeBook.Infrastructure.Services;
using Refit;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddServices(services);
        AddRefit(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IGetAccessToken, GetAccessTokenService>();
    }    
    private static void AddRefit(IServiceCollection services)
    {
        services.AddRefitClient<ICtrlPlayClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://portal.ctrlplay.com.br/api/api/v1"));
    }
}