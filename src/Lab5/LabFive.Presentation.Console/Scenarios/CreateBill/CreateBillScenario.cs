using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.CreateBill;

public class CreateBillScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateBillScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create Bill";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Enter password: ");
        string password = AnsiConsole.Ask<string>("Enter password: ");

        _userService.CreateBill(name, password);

        AnsiConsole.Ask<string>("Ok");
    }
}