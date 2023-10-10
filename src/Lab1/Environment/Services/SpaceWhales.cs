using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class SpaceWhales : Obstacle
{
    private const int PowerOfObstacleDamage = 21000;

    public override VoyageOutcomeType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.HullStrength is not null)
        {
            if (spaceship.AntiNitrineEmitter is true)
            {
                return VoyageOutcomeType.NoError;
            }

            if (spaceship.Deflector is not null)
            {
                if (spaceship.Deflector.DeflectObstacle(PowerOfObstacleDamage) is false)
                {
                    return VoyageOutcomeType.ShipDestroyed;
                }
            }
            else
            {
                return VoyageOutcomeType.ShipDestroyed;
            }
        }

        return VoyageOutcomeType.NoError;
    }
}