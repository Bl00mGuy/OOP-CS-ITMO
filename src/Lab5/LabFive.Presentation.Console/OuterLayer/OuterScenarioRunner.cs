using Spectre.Console;

namespace LabFive.Presentation.Console.OuterLayer;

public class OuterScenarioRunner
{
    private readonly IEnumerable<IOuterScenarioProvider> _providers;

    public OuterScenarioRunner(IEnumerable<IOuterScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IOuterScenario> intermediateScenarios = GetScenarios();

        SelectionPrompt<IOuterScenario> selector = new SelectionPrompt<IOuterScenario>()
            .Title("Select action")
            .AddChoices(intermediateScenarios)
            .UseConverter(x => x.Name);

        IOuterScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IOuterScenario> GetScenarios()
    {
        foreach (IOuterScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IOuterScenario? scenario))
                yield return scenario;
        }
    }
}