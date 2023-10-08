using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class SpaceWhales : Obstacle
{
    private const int PowerOfObstacleDamage = 21000;

    public override VoyageErrorType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.HullStrength != null)
        {
            if (spaceship.AntiNitrineEmitter == true)
            {
                return VoyageErrorType.NoError;
            }

            if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(PowerOfObstacleDamage) == false)
                {
                    return VoyageErrorType.ShipDestroyed;
                }
            }
            else
            {
                return VoyageErrorType.ShipDestroyed;
            }
        }

        return VoyageErrorType.NoError;
    }
}