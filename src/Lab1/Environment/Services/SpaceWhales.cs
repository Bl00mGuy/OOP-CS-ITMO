using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class SpaceWhales : Entities.Obstacle
{
    public override string ObstacleHit(Spaceship spaceship)
    {
        if (spaceship != null && spaceship.HullStrength != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.AntiNitrineEmitter == true)
            {
                return "OK";
            }

            if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(ObstacleType.SpaceWhale) == false)
                {
                    spaceship.SetShipStatus(false);
                    spaceship.SetCrewStatus(false);
                    return "The spaceship has been destroyed";
                }
            }
            else
            {
                spaceship.SetShipStatus(false);
                spaceship.SetCrewStatus(false);
                return "The spaceship has been destroyed";
            }
        }

        return "OK";
    }
}