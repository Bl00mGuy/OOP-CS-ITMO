namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NormalSpace : Entities.Environment
{
    public NormalSpace(int smallAsteroidsCount, int meteoritesCount, int lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class C");
        AddRequiredEngineName("Impulse Engine Class E");
        AddObstacle("Meteorite", meteoritesCount);
        AddObstacle("SmallAsteroid", smallAsteroidsCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}