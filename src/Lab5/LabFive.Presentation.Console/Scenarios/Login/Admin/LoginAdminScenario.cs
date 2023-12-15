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

    public string Name => "Login as Admin";

    public void Run()
    {
        string passwd = AnsiConsole.Ask<string>("Enter secret password: ");

        LoginResult result = _adminService.Login(passwd);

        string message = result switch
        {
            LoginResult.Success => "Successful login!",
            LoginResult.NotFound => "Incorrect password!",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        while (true)
        {
            _scenarioRunner.Run();
        }
    }
}