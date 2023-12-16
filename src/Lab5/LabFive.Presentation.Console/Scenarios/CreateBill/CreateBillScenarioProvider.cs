using System.Diagnostics.CodeAnalysis;
using LabFive.Application.Contracts.Users;
using LabFive.Presentation.Console.IntermediateLayer;

namespace LabFive.Presentation.Console.Scenarios.CreateBill;

public class CreateBillScenarioProvider : IIntermediateScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public CreateBillScenarioProvider(IUserService service, ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IIntermediateScenario? intermediateScenario)
    {
        if (_currentUser.User is not null)
        {
            intermediateScenario = null;
            return false;
        }

        intermediateScenario = new CreateBillScenario(_service);
        return true;
    }
}