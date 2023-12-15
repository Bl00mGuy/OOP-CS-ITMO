using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.CreateBill;

public class CreateBillScenario : IIntermediateScenario
{
    private readonly IUserService _userService;

    public CreateBillScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create Account";

    public void Run()
    {
        AnsiConsole.Clear();

        string name = AnsiConsole.Ask<string>("Enter name: ");
        string password = AnsiConsole.Ask<string>("Enter password: ");

        _userService.CreateBill(name, password);

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}