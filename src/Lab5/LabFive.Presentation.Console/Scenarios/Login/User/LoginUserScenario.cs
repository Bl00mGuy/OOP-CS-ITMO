using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.Login.User;

public class LoginUserScenario : IIntermediateScenario
{
    private readonly IUserService _userService;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginUserScenario(IUserService userService, ScenarioRunner scenarioRunner)
    {
        _userService = userService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Login as User";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Enter your Name: ");
        string password = AnsiConsole.Ask<string>("Enter your Password, he-he: ");

        LoginResult result = _userService.Login(name, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login!",
            LoginResult.NotFound => "User not found!",
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