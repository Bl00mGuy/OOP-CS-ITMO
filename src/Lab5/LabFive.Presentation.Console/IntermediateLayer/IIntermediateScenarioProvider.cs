using System.Diagnostics.CodeAnalysis;

namespace LabFive.Presentation.Console.IntermediateLayer;

public interface IIntermediateScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IIntermediateScenario? intermediateScenario);
}