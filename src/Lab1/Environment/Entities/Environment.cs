using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Environment
{
    private readonly Collection<string> _requiredEngineNames = new();
    private readonly Collection<string> _requiredJumpEngineNames = new();

    public double LengthOfEnvironment { get; protected init; }

    private ReadOnlyCollection<string> RequiredEngineNames => _requiredEngineNames.AsReadOnly();
    private ReadOnlyCollection<string> RequiredJumpEngineNames => _requiredJumpEngineNames.AsReadOnly();
    private Dictionary<string, int> Obstacles { get; } = new();

    protected static string ShipEnterSphere(Spaceship spaceship, Environment segment)
    {
        if (spaceship.Engine != null)
        {
            switch (segment)
            {
                case NormalSpace:
                    if (segment.RequiredEngineNames.Contains(spaceship.Engine.EngineName))
                    {
                        if (segment.Obstacles.TryGetValue("SmallAsteroid", out int smallAsteroidCount))
                        {
                            for (int i = 0; i < smallAsteroidCount; i++)
                            {
                                var smallAsteroid = new SmallAsteroid();
                                string shipHit = smallAsteroid.ObstacleHit(spaceship);
                                if (!Equals(shipHit, "OK"))
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
                                string shipHit = meteorite.ObstacleHit(spaceship);
                                if (!Equals(shipHit, "OK"))
                                {
                                    return shipHit;
                                }
                            }
                        }
                    }
                    else
                    {
                        return "Spaceship doesn't have a required engine!";
                    }

                    break;

                case HighDensityFog:
                    if (spaceship.JumpEngine != null)
                    {
                        if (segment.RequiredEngineNames.Contains(spaceship.Engine.EngineName) && segment.RequiredJumpEngineNames.Contains(spaceship.JumpEngine.EngineName))
                        {
                            if (segment.LengthOfEnvironment > spaceship.JumpEngine.MaxJumpLength)
                            {
                                return "Spaceship doesn't have a required jump engine max jump length!";
                            }

                            if (segment.Obstacles.TryGetValue("AntimatterFlare", out int antimatterFlaresCount))
                            {
                                for (int i = 0; i < antimatterFlaresCount; i++)
                                {
                                    var antimatterFlare = new AntimatterFlares();
                                    string shipHit = antimatterFlare.ObstacleHit(spaceship);
                                    if (!Equals(shipHit, "OK"))
                                    {
                                        return shipHit;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return "Spaceship doesn't have a required jump engine!";
                    }

                    break;

                case NitrineParticleFog:
                    if (segment.RequiredEngineNames.Contains(spaceship.Engine.EngineName))
                    {
                        if (segment.Obstacles.TryGetValue("SpaceWhale", out int spaceWhalesCount))
                        {
                            for (int i = 0; i < spaceWhalesCount; i++)
                            {
                                var spaceWhales = new SpaceWhales();
                                string shipHit = spaceWhales.ObstacleHit(spaceship);
                                if (!Equals(shipHit, "OK"))
                                {
                                    return shipHit;
                                }
                            }
                        }
                    }
                    else
                    {
                        return "Spaceship doesn't have a required engine!";
                    }

                    break;
            }
        }

        return "OK";
    }

    protected void AddRequiredEngineName(string engineName)
    {
        _requiredEngineNames.Add(engineName);
    }

    protected void AddRequiredJumpEngineName(string jumpEngineName)
    {
        _requiredJumpEngineNames.Add(jumpEngineName);
    }

    protected void AddObstacle(string obstacle, int count)
    {
        Obstacles[obstacle] = count;
    }
}