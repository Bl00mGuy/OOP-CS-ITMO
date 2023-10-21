using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Environments
{
    private readonly IList<Obstacle> _obstacles = new List<Obstacle>();

    public NitrineParticleFog(IList<Obstacle> obstacles, double lengthOfEnvironment)
        : base(lengthOfEnvironment)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle is NitrineParticleFogObstacles)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public override VoyageOutcomeType ShipEnterSphere(Spaceship spaceship)
    {
        if (spaceship.Engine is ImpulseEngineClassE)
        {
            foreach (Obstacle obstacle in _obstacles)
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