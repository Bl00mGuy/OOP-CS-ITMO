using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class AntimatterFlares : Entities.Obstacle
{
    public override void ObstacleHit(Spaceship spaceship)
    {
        if (spaceship != null && spaceship.IsCrewAlive == true && spaceship.IsShipAlive == true)
        {
            if (spaceship.PhotonDeflector != null)
            {
                if (spaceship.PhotonDeflector.DeflectObstacle(ObstacleType.AntimatterFlare) == false)
                {
                    spaceship.SetCrewStatus(false);
                    Console.WriteLine($"The {spaceship.Name} crew died.");
                    return;
                }
            }
            else
            {
                spaceship.SetCrewStatus(false);
                Console.WriteLine($"The {spaceship.Name} crew died.");
                return;
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot hit a spaceship (SHIP MISSING OR [DESTROYED/DIED]).");
        }
    }
}