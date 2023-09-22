using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IHullStrength
{
    string Name { get; }
    bool HullObstacle(ObstacleType obstacleType);
}