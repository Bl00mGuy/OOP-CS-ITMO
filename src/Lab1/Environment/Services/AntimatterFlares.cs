using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : Obstacle
{
    public override string ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.PhotonDeflector != null)
            {
                spaceship.PhotonDeflector.DeflectObstacle(spaceship, ObstacleType.AntimatterFlare);
            }
            else
            {
                spaceship.SetCrewStatus(false);
                return "The ship's crew died";
            }
        }

        return "OK";
    }
}