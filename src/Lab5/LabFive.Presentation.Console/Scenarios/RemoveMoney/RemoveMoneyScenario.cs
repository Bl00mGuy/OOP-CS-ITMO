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
        long password = AnsiConsole.Ask<long>("How much money you wish to withdraw from your account: ");

        _userService.RemoveMoney(password);

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}