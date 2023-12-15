using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.PutMoney;

public class PutMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public PutMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Put Money";

    public void Run()
    {
        AnsiConsole.Clear();

        decimal money = AnsiConsole.Ask<long>("How much money you wish to deposit into the account: ");

        _userService.PutMoney(money);
        _userService.LogTransaction("PutMoney", money);

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}