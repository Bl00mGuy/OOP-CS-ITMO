using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class SmallAsteroid : Obstacle
{
    private const int PowerOfObstacleDamage = 210;

    public override VoyageErrorType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.HullStrength != null)
        {
            if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(PowerOfObstacleDamage) == false)
                {
                    if (spaceship.HullStrength.HullObstacle(PowerOfObstacleDamage) == false)
                    {
                        return VoyageErrorType.ShipDestroyed;
                    }
                }
            }
            else
            {
                if (spaceship.HullStrength.HullObstacle(PowerOfObstacleDamage) == false)
                {
                    return VoyageErrorType.ShipDestroyed;
                }
            }
        }

        return VoyageErrorType.NoError;
    }
}