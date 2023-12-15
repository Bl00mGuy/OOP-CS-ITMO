using Spectre.Console;

namespace LabFive.Presentation.Console.IntermediateLayer;

public class IntermediateScenarioRunner
{
    private readonly IEnumerable<IIntermediateScenarioProvider> _providers;

    public IntermediateScenarioRunner(IEnumerable<IIntermediateScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IIntermediateScenario> intermediateScenarios = GetScenarios();

        SelectionPrompt<IIntermediateScenario> selector = new SelectionPrompt<IIntermediateScenario>()
            .Title("Select action")
            .AddChoices(intermediateScenarios)
            .UseConverter(x => x.Name);

        IIntermediateScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IIntermediateScenario> GetScenarios()
    {
        foreach (IIntermediateScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IIntermediateScenario? scenario))
                yield return scenario;
        }
    }
}