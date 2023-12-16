using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : HighDensityFogObstacles
{
    public AntimatterFlares(int countOfObstacles)
        : base(countOfObstacles)
    {
    }

    public override VoyageOutcomeType ObstacleHit(Spaceship spaceship)
    {
        for (int i = 0; i < CountOfObstacles; i++)
        {
            if (spaceship.Deflector?.HasPhotonDeflectAddition is not null)
            {
                spaceship.Deflector.HasPhotonDeflectAddition.DeflectObstacle();
            }
            else
            {
                return VoyageOutcomeType.CrewDied;
            }
        }

        return VoyageOutcomeType.NoError;
    }
}