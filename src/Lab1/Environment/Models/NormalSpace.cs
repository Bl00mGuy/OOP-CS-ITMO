using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NormalSpace : Environments
{
    public NormalSpace(int smallAsteroidsCount, int meteoritesCount, double lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class C");
        AddRequiredEngineName("Impulse Engine Class E");
        AddObstacle("Meteorite", meteoritesCount);
        AddObstacle("SmallAsteroid", smallAsteroidsCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}