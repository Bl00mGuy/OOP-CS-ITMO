using System.Globalization;
using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public GetBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "See Balance";

    public void Run()
    {
        decimal? result = _userService.GetBalance();

        if (result is null) return;
        AnsiConsole.WriteLine(CultureInfo.InvariantCulture, "{0}", result);
        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}