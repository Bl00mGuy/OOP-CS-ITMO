using System.Diagnostics.CodeAnalysis;

namespace LabFive.Presentation.Console.OuterLayer;

public interface IOuterScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IOuterScenario? intermediateScenario);
}