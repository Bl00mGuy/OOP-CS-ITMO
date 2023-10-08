using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : Obstacle
{
    public override VoyageErrorType ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.Deflector != null && spaceship.Deflector.HasPhotonDeflectAddition != null)
        {
            spaceship.Deflector.HasPhotonDeflectAddition.DeflectObstacle();
        }
        else
        {
            return VoyageErrorType.CrewDied;
        }

        return VoyageErrorType.NoError;
    }
}