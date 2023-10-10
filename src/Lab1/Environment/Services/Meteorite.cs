using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class Meteorite : Obstacle
{
    private const int PowerOfObstacleDamage = 840;

    public override VoyageOutcomeType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.HullStrength is not null)
        {
            if (spaceship.Deflector is not null)
            {
                if (spaceship.Deflector.DeflectObstacle(PowerOfObstacleDamage) is false)
                {
                    if (spaceship.HullStrength.HullObstacle(PowerOfObstacleDamage) is false)
                    {
                        return VoyageOutcomeType.ShipDestroyed;
                    }
                }
            }
            else
            {
                if (spaceship.HullStrength.HullObstacle(PowerOfObstacleDamage) is false)
                {
                    return VoyageOutcomeType.ShipDestroyed;
                }
            }
        }

        return VoyageOutcomeType.NoError;
    }
}