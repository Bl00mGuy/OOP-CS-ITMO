namespace LabFive.Presentation.Console.IntermediateLayer;

public interface IIntermediateScenario
{
    string Name { get; }

    void Run();
}