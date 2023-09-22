using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IDeflector
{
    string Name { get; }
    bool DeflectObstacle(ObstacleType obstacleType);
}