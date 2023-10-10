using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Environments
{
    public double LengthOfEnvironment { get; protected init; }
    private List<Obstacle> Obstacles { get; } = new();

    protected static VoyageOutcomeType ShipEnterSphere(Spaceship spaceship, Environments segment)
    {
        if (spaceship.Engine is not null)
        {
            switch (segment)
            {
                case NormalSpace:
                    if (spaceship.Engine is IImpulseEngine)
                    {
                        foreach (Obstacle obstacle in segment.Obstacles)
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

                    break;

                case HighDensityFog:
                    if (spaceship.JumpEngine is not null)
                    {
                        if (spaceship.Engine is IImpulseEngine)
                        {
                            if (spaceship.JumpEngine is IJumpEngine)
                            {
                                if (segment.LengthOfEnvironment > spaceship.JumpEngine.MaxJumpLength)
                                {
                                    return VoyageOutcomeType.MaxJumpLengthExceeded;
                                }

                                foreach (Obstacle obstacle in segment.Obstacles)
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

                    break;

                case NitrineParticleFog:
                    if (spaceship.Engine is ImpulseEngineClassE)
                    {
                        foreach (Obstacle obstacle in segment.Obstacles)
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

                    break;
            }
        }

        return VoyageOutcomeType.NoError;
    }

    protected void AddObstacle(Obstacle obstacle, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Obstacles.Add(obstacle);
        }
    }
}