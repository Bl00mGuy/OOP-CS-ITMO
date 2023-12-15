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
        long password = AnsiConsole.Ask<long>("How much money you wish to deposit into the account: ");

        _userService.PutMoney(password);

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}