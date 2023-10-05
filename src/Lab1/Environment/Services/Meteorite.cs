using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class Meteorite : Obstacle
{
    public override string ObstacleHit(Spaceship spaceship)
    {
        if (spaceship.HullStrength != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(ObstacleType.Meteorite) == false)
                {
                    if (spaceship.HullStrength.HullObstacle(ObstacleType.Meteorite) == false)
                    {
                        spaceship.SetShipStatus(false);
                        spaceship.SetCrewStatus(false);
                        return "The spaceship has been destroyed";
                    }
                }
            }
            else
            {
                if (spaceship.HullStrength.HullObstacle(ObstacleType.Meteorite) == false)
                {
                    spaceship.SetShipStatus(false);
                    spaceship.SetCrewStatus(false);
                    return "The spaceship has been destroyed";
                }
            }
        }

        return "OK";
    }
}