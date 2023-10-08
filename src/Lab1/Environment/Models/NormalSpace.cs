using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NormalSpace : Environments
{
    public NormalSpace(int smallAsteroidsCount, int meteoritesCount, double lengthOfEnvironment)
    {
        RequiredEngines = typeof(IEngine);
        AddObstacle(new Meteorite(), meteoritesCount);
        AddObstacle(new SmallAsteroid(), smallAsteroidsCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}