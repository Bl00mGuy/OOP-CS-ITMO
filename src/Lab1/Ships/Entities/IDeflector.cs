using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IDeflector
{
    bool DeflectObstacle(Spaceship spaceship, ObstacleType obstacleType);
}