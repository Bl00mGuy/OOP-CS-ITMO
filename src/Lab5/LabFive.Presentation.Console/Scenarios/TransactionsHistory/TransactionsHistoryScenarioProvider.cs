using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;

namespace LabFive.Presentation.Console.Scenarios.TransactionsHistory;

public class TransactionsHistoryScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;

    public TransactionsHistoryScenarioProvider(IAdminService service, ICurrentAdminService currentAdmin)
    {
        _adminService = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new TransactionsHistoryScenario(_adminService);
        return true;
    }
}