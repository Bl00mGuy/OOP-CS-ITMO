using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Obstacle
{
    public abstract string ObstacleHit(Spaceship spaceship);
}