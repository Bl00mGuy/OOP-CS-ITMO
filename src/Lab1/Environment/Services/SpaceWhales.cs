using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class SpaceWhales : Entities.Obstacle
{
    public override void ObstacleHit(Spaceship spaceship)
    {
        if (spaceship != null && spaceship.HullStrength != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.AntiNitrineEmitter == true)
            {
                Console.WriteLine($"Ship {spaceship.Name} repelled the attack of space-whales with an anti-nitrine emitter.");
                return;
            }
            else if (spaceship.Deflector != null)
            {
                if (spaceship.Deflector.DeflectObstacle(ObstacleType.SpaceWhale) == false)
                {
                    spaceship.SetShipStatus(false);
                    spaceship.SetCrewStatus(false);
                    Console.WriteLine($"Ship {spaceship.Name} is destroyed.");
                    return;
                }
            }
            else
            {
                spaceship.SetShipStatus(false);
                spaceship.SetCrewStatus(false);
                Console.WriteLine($"Ship {spaceship.Name} is destroyed.");
                return;
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot hit a spaceship (SHIP MISSING OR [DESTROYED/DIED]).");
        }
    }
}