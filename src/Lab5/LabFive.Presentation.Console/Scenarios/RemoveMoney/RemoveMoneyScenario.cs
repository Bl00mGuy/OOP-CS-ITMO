using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.RemoveMoney;

public class RemoveMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public RemoveMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Remove Money";

    public void Run()
    {
        AnsiConsole.Clear();

        decimal money = AnsiConsole.Ask<long>("How much money you wish to withdraw from your account: ");

        var status = (OperationStatus)_userService.RemoveMoney(money);
        _userService.LogTransaction("RemoveMoney", money);

        if (status is OperationStatus.Failed)
        {
            AnsiConsole.WriteLine("#OPERATION FAILED#");
            return;
        }

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}