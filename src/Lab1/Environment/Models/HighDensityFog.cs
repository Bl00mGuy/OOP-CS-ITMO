using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class HighDensityFog : Environments
{
    private readonly IList<Obstacle> _obstacles = new List<Obstacle>();

    public HighDensityFog(IList<Obstacle> obstacles, double lengthOfEnvironment)
        : base(lengthOfEnvironment)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle is HighDensityFogObstacles)
            {
                _obstacles.Add(obstacle);
            }
        }
    }

    public override VoyageOutcomeType ShipEnterSphere(Spaceship spaceship)
    {
        if (spaceship.JumpEngine is not null)
        {
            if (spaceship.Engine is IImpulseEngine)
            {
                if (spaceship.JumpEngine is IJumpEngine)
                {
                    if (LengthOfEnvironment > spaceship.JumpEngine.MaxJumpLength)
                    {
                        return VoyageOutcomeType.MaxJumpLengthExceeded;
                    }

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
                    return VoyageOutcomeType.MissingRequiredJumpEngine;
                }
            }
            else
            {
                return VoyageOutcomeType.MissingRequiredEngine;
            }
        }
        else
        {
            return VoyageOutcomeType.MissingRequiredJumpEngine;
        }

        return VoyageOutcomeType.NoError;
    }
}