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
        decimal money = AnsiConsole.Ask<long>("How much money you wish to withdraw from your account: ");

        _userService.RemoveMoney(money);
        _userService.LogTransaction("RemoveMoney", money);

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}