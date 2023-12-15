using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.Login.Admin;

public class LoginAdminScenario : IIntermediateScenario
{
    private readonly IAdminService _adminService;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginAdminScenario(IAdminService adminService, ScenarioRunner scenarioRunner)
    {
        _adminService = adminService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "ADMIN Login";

    public void Run()
    {
        AnsiConsole.Clear();

        string passwd = AnsiConsole.Ask<string>("Sudo su password: ");

        LoginResult result = _adminService.Login(passwd);

        string message = result switch
        {
            LoginResult.Success => "Successful login!",
            LoginResult.NotFound => "Incorrect password!",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        if (result is LoginResult.NotFound)
        {
            AnsiConsole.Clear();
            return;
        }

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("#OPERATION COMPLETED#");

        while (true)
        {
            _scenarioRunner.Run();
        }
    }
}