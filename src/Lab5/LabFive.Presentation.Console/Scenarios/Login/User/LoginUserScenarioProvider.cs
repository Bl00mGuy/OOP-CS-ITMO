using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;

namespace LabFive.Presentation.Console.Scenarios.Login.User;

public class LoginUserScenarioProvider : IIntermediateScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginUserScenarioProvider(IUserService service, ICurrentUserService currentUser, ScenarioRunner scenarioRunner)
    {
        _userService = service;
        _currentUser = currentUser;
        _scenarioRunner = scenarioRunner;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IIntermediateScenario? intermediateScenario)
    {
        if (_currentUser.User is not null)
        {
            intermediateScenario = null;
            return false;
        }

        intermediateScenario = new LoginUserScenario(_userService, _scenarioRunner);
        return true;
    }
}