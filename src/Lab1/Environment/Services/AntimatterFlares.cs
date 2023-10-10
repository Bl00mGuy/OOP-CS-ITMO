using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : Obstacle
{
    public override VoyageOutcomeType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.Deflector?.HasPhotonDeflectAddition is not null)
        {
            spaceship.Deflector.HasPhotonDeflectAddition.DeflectObstacle();
        }
        else
        {
            return VoyageOutcomeType.CrewDied;
        }

        return VoyageOutcomeType.NoError;
    }
}