using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class ShipEntersSphere
{
    public static void ShipEnterSphere(Spaceship spaceship, Environment segment)
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
                                smallAsteroid.ObstacleHit(spaceship);
                            }
                        }

                        if (segment.Obstacles.TryGetValue("Meteorite", out int meteoriteCount))
                        {
                            for (int i = 0; i < meteoriteCount; i++)
                            {
                                var meteorite = new Meteorite();
                                meteorite.ObstacleHit(spaceship);
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Spaceship doesn't have a required engine for Normal Space!");
                    }

                    break;

                case HighDensityFog:
                    if (spaceship.JumpEngine != null)
                    {
                        if (segment.RequiredEngineNames.Contains(spaceship.Engine.EngineName) && segment.RequiredJumpEngineNames.Contains(spaceship.JumpEngine.EngineName))
                        {
                            // Доделать прыжки в дистанцию
                            if (segment.Obstacles.TryGetValue("AntimatterFlare", out int antimatterFlaresCount))
                            {
                                for (int i = 0; i < antimatterFlaresCount; i++)
                                {
                                    var antimatterFlare = new AntimatterFlares();
                                    antimatterFlare.ObstacleHit(spaceship);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Spaceship doesn't have a required engine for High-Density Fog!");
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
                                spaceWhales.ObstacleHit(spaceship);
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Spaceship doesn't have a required engine for Nitrine-Particle Fog!");
                    }

                    break;
            }
        }
    }
}