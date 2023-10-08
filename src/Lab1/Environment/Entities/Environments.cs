using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Environments
{
    public double LengthOfEnvironment { get; protected init; }
    protected Type? RequiredEngines { get; init; }
    protected Type? RequiredJumpEngines { get; init; }
    private Dictionary<string, int> Obstacles { get; } = new();

    protected static VoyageErrorType ShipEnterSphere(Spaceship spaceship, Environments segment)
    {
        if (spaceship.Engine != null)
        {
            switch (segment)
            {
                case NormalSpace:
                    if (segment.RequiredEngines != null && segment.RequiredEngines.IsInstanceOfType(spaceship.Engine))
                    {
                        if (segment.Obstacles.TryGetValue("SmallAsteroid", out int smallAsteroidCount))
                        {
                            for (int i = 0; i < smallAsteroidCount; i++)
                            {
                                var smallAsteroid = new SmallAsteroid();
                                VoyageErrorType shipHit = smallAsteroid.ObstacleHit(spaceship);
                                if (!Equals(shipHit, VoyageErrorType.NoError))
                                {
                                    return shipHit;
                                }
                            }
                        }

                        if (segment.Obstacles.TryGetValue("Meteorite", out int meteoriteCount))
                        {
                            for (int i = 0; i < meteoriteCount; i++)
                            {
                                var meteorite = new Meteorite();
                                VoyageErrorType shipHit = meteorite.ObstacleHit(spaceship);
                                if (!Equals(shipHit, VoyageErrorType.NoError))
                                {
                                    return shipHit;
                                }
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

                                if (segment.Obstacles.TryGetValue("AntimatterFlare", out int antimatterFlaresCount))
                                {
                                    for (int i = 0; i < antimatterFlaresCount; i++)
                                    {
                                        var antimatterFlare = new AntimatterFlares();
                                        VoyageErrorType shipHit = antimatterFlare.ObstacleHit(spaceship);
                                        if (!Equals(shipHit, VoyageErrorType.NoError))
                                        {
                                            return shipHit;
                                        }
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
                        if (segment.Obstacles.TryGetValue("SpaceWhale", out int spaceWhalesCount))
                        {
                            for (int i = 0; i < spaceWhalesCount; i++)
                            {
                                var spaceWhales = new SpaceWhales();
                                VoyageErrorType shipHit = spaceWhales.ObstacleHit(spaceship);
                                if (!Equals(shipHit, VoyageErrorType.NoError))
                                {
                                    return shipHit;
                                }
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

    protected void AddObstacle(string obstacle, int count)
    {
        Obstacles[obstacle] = count;
    }
}