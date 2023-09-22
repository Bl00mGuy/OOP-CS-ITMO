using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class Meteorite : Entities.Obstacle
{
    public override void ObstacleHit(Spaceship spaceship)
    {
        if (spaceship != null && spaceship.HullStrength != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(ObstacleType.Meteorite) == false)
                {
                    Console.WriteLine($"Ship {spaceship.Name} deflector is destroyed.");
                    if (spaceship.HullStrength.HullObstacle(ObstacleType.Meteorite) == false)
                    {
                        spaceship.SetShipStatus(false);
                        spaceship.SetCrewStatus(false);
                        Console.WriteLine($"Ship {spaceship.Name} is destroyed.");
                        return;
                    }
                }
            }
            else
            {
                if (spaceship.HullStrength.HullObstacle(ObstacleType.Meteorite) == false)
                {
                    spaceship.SetShipStatus(false);
                    spaceship.SetCrewStatus(false);
                    Console.WriteLine($"Ship {spaceship.Name} is destroyed.");
                    return;
                }
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot hit a spaceship (SHIP MISSING OR [DESTROYED/DIED]).");
        }
    }
}