using Microsoft.Extensions.DependencyInjection;
using WhereIsHong.Services.Queries;

namespace WhereIsHong.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWhereIsHongServices(this IServiceCollection services)
    {
        services
            .AddOptions<WhereIsHongOptions>()
            .BindConfiguration("WhereIsHong")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetJournalEntriesQuery>());

        return services;
    }
}
