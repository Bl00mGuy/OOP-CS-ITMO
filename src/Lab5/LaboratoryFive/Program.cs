using LabFive.Application.Extensions;
using LabFive.Infrastructure.DataAccess.Extensions;
using LabFive.Presentation.Console.Extensions;
using LabFive.Presentation.Console.IntermediateLayer;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

IntermediateScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<IntermediateScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}