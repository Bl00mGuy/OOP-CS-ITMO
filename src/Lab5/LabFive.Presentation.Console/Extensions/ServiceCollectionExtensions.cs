using LabFive.Presentation.Console.IntermediateLayer;
using LabFive.Presentation.Console.Scenarios.CreateBill;
using LabFive.Presentation.Console.Scenarios.GetBalance;
using LabFive.Presentation.Console.Scenarios.Login.Admin;
using LabFive.Presentation.Console.Scenarios.Login.User;
using LabFive.Presentation.Console.Scenarios.PutMoney;
using LabFive.Presentation.Console.Scenarios.RemoveMoney;
using LabFive.Presentation.Console.Scenarios.TransactionsHistory;
using Microsoft.Extensions.DependencyInjection;

namespace LabFive.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IntermediateScenarioRunner>();

        collection.AddScoped<IIntermediateScenarioProvider, CreateBillScenarioProvider>();
        collection.AddScoped<IIntermediateScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IIntermediateScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, PutMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RemoveMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionsHistoryScenarioProvider>();

        return collection;
    }
}