using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;

namespace LabFive.Presentation.Console.Scenarios.Login.Admin;

public class LoginAdminScenarioProvider : IIntermediateScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginAdminScenarioProvider(IAdminService service, ICurrentAdminService currentUser, ScenarioRunner scenarioRunner)
    {
        _adminService = service;
        _currentAdmin = currentUser;
        _scenarioRunner = scenarioRunner;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IIntermediateScenario? intermediateScenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            intermediateScenario = null;
            return false;
        }

        intermediateScenario = new LoginAdminScenario(_adminService, _scenarioRunner);
        return true;
    }
}