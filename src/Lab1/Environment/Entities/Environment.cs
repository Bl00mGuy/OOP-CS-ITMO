using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Environment
{
    private readonly Collection<string> _requiredEngineNames = new Collection<string>();
    public ReadOnlyCollection<string> RequiredEngineNames => _requiredEngineNames.AsReadOnly();

    public Dictionary<string, int> Obstacles { get; } = new Dictionary<string, int>();

    public double LengthOfEnvironment { get; protected set; }

    public void AddRequiredEngineName(string engineName)
    {
        _requiredEngineNames.Add(engineName);
    }

    public void RemoveRequiredEngineName(string engineName)
    {
        _requiredEngineNames.Remove(engineName);
    }

    public void AddObstacle(string obstacle, int count)
    {
        Obstacles[obstacle] = count;
    }

    public void RemoveObstacle(string obstacle)
    {
        Obstacles.Remove(obstacle);
    }
}