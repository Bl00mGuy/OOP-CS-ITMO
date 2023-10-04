using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : Entities.Obstacle
{
    public override string ObstacleHit(Spaceship spaceship)
    {
        if (spaceship != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.PhotonDeflector != null)
            {
                if (spaceship.PhotonDeflector.DeflectObstacle(ObstacleType.AntimatterFlare) == false)
                {
                    spaceship.SetCrewStatus(false);
                    return "The ship's crew died";
                }
            }
            else
            {
                spaceship.SetCrewStatus(false);
                return "The ship's crew died";
            }
        }

        return "Cannot hit a spaceship (SHIP MISSING OR [DESTROYED/DIED]).";
    }
}