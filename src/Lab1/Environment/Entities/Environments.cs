using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Environments
{
    public double LengthOfEnvironment { get; protected init; }
    protected Type? RequiredEngines { get; init; }
    protected Type? RequiredJumpEngines { get; init; }
    private List<Obstacle> Obstacles { get; } = new();

    protected static VoyageErrorType ShipEnterSphere(Spaceship spaceship, Environments segment)
    {
        if (spaceship.Engine != null)
        {
            switch (segment)
            {
                case NormalSpace:
                    if (segment.RequiredEngines != null && segment.RequiredEngines.IsInstanceOfType(spaceship.Engine))
                    {
                        foreach (Obstacle obstacle in segment.Obstacles)
                        {
                            VoyageErrorType shipHit = obstacle.ObstacleHit(spaceship);
                            if (!Equals(shipHit, VoyageErrorType.NoError))
                            {
                                return shipHit;
                            }
                        }
                    }
                    else
                    {
                        return VoyageErrorType.MissingRequiredEngine;
                    }

                    break;

                case HighDensityFog:
                    if (spaceship.JumpEngine != null)
                    {
                        if (segment.RequiredEngines != null && segment.RequiredEngines.IsInstanceOfType(spaceship.Engine))
                        {
                            if (segment.RequiredJumpEngines != null && segment.RequiredJumpEngines.IsInstanceOfType(spaceship.JumpEngine))
                            {
                                if (segment.LengthOfEnvironment > spaceship.JumpEngine.MaxJumpLength)
                                {
                                    return VoyageErrorType.MaxJumpLengthExceeded;
                                }

                                foreach (Obstacle obstacle in segment.Obstacles)
                                {
                                    VoyageErrorType shipHit = obstacle.ObstacleHit(spaceship);
                                    if (!Equals(shipHit, VoyageErrorType.NoError))
                                    {
                                        return shipHit;
                                    }
                                }
                            }
                            else
                            {
                                return VoyageErrorType.MissingRequiredJumpEngine;
                            }
                        }
                        else
                        {
                            return VoyageErrorType.MissingRequiredEngine;
                        }
                    }
                    else
                    {
                        return VoyageErrorType.MissingRequiredJumpEngine;
                    }

                    break;

                case NitrineParticleFog:
                    if (segment.RequiredEngines != null && segment.RequiredEngines.IsInstanceOfType(spaceship.Engine))
                    {
                        foreach (Obstacle obstacle in segment.Obstacles)
                        {
                            VoyageErrorType shipHit = obstacle.ObstacleHit(spaceship);
                            if (!Equals(shipHit, VoyageErrorType.NoError))
                            {
                                return shipHit;
                            }
                        }
                    }
                    else
                    {
                        return VoyageErrorType.MissingRequiredEngine;
                    }

                    break;
            }
        }

        return VoyageErrorType.NoError;
    }

    protected void AddObstacle(Obstacle obstacle, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Obstacles.Add(obstacle);
        }
    }
}