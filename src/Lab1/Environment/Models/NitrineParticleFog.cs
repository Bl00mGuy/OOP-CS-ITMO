using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Environments
{
    public NitrineParticleFog(IList<Obstacle> obstacles, double lengthOfEnvironment)
        : base(lengthOfEnvironment)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle is NitrineParticleFogObstacles)
            {
                Obstacles.Add(obstacle);
            }
        }
    }

    public override VoyageOutcomeType ShipEnterSphere(Spaceship spaceship)
    {
        if (spaceship.Engine is ImpulseEngineClassE)
        {
            foreach (Obstacle obstacle in Obstacles)
            {
                VoyageOutcomeType shipHit = obstacle.ObstacleHit(spaceship);
                if (!Equals(shipHit, VoyageOutcomeType.NoError))
                {
                    return shipHit;
                }
            }
        }
        else
        {
            return VoyageOutcomeType.MissingRequiredEngine;
        }

        return VoyageOutcomeType.NoError;
    }
}