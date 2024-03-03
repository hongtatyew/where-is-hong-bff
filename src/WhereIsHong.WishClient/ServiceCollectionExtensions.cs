using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.Extensions.Options;

namespace WhereIsHong.WishClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWishClient(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<WishClientOptions>()
            .BindConfiguration("WishClient")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // services.Configure<WishClientOptions>(configuration.GetSection("WishClient"));
        services.AddScoped<IJournalRepository, JournalRepository>();
        services.AddHttpClient<IJournalRepository, JournalRepository>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<WishClientOptions>>();
            httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {options.Value.Authorization}");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Api-Key", options.Value.ApiKey);
        });


        return services;
    }
}
