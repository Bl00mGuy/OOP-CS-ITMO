using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Obstacle
{
    protected Obstacle(int countOfObstacles)
    {
        CountOfObstacles = countOfObstacles;
    }

    protected int CountOfObstacles { get; }
    public abstract VoyageOutcomeType ObstacleHit(Spaceship spaceship);
}