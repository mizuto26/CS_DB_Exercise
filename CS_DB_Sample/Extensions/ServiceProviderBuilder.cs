using CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Domains.Repositories;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace CS_DB_Exercise.CS_DB_Sample.Extensions;

public static class ServiceProviderBuilder
{
    public static IServiceProvider Build()
    {
        var services = new ServiceCollection();
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IItemAdapter<ItemEntity>,
                            ItemEntityAdapter>();

        services.AddScoped<IItemRepository, ItemRepository>();

        var provider = services.BuildServiceProvider();
        return provider;
    }
}