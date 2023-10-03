using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Environment : ShipEntersSphere
{
    private readonly Collection<string> _requiredEngineNames = new Collection<string>();
    private readonly Collection<string> _requiredJumpEngineNames = new Collection<string>(); // Добавление коллекции для требуемых прыжковых двигателей

    public ReadOnlyCollection<string> RequiredEngineNames => _requiredEngineNames.AsReadOnly();
    public ReadOnlyCollection<string> RequiredJumpEngineNames => _requiredJumpEngineNames.AsReadOnly(); // Добавление свойства для RequiredJumpEngineNames

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

    public void AddRequiredJumpEngineName(string jumpEngineName) // Метод для добавления требуемых прыжковых двигателей
    {
        _requiredJumpEngineNames.Add(jumpEngineName);
    }

    public void RemoveRequiredJumpEngineName(string jumpEngineName) // Метод для удаления требуемых прыжковых двигателей
    {
        _requiredJumpEngineNames.Remove(jumpEngineName);
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