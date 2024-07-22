using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Azure.Cosmos;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);

        var cosmosConnectionString = Environment.GetEnvironmentVariable("CosmosConnectionString");
        var cosmosClient = new CosmosClient(cosmosConnectionString);
        services.AddSingleton(cosmosClient);
    })
    .Build();

host.Run();
