using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class DeflectorClass1 : Entities.IDeflector
{
    private int _remainingSmallAsteroidsHits = 2;
    private int _remainingMeteoriteHits = 1;

    public bool IsDeflectorAlive { get; private set; } = true;
    public string Name => "Deflector Class 1";

    public bool DeflectObstacle(ObstacleType obstacleType)
    {
        if (IsDeflectorAlive == false)
        {
            return false;
        }

        switch (obstacleType)
        {
            case ObstacleType.SmallAsteroid:
                if (_remainingSmallAsteroidsHits > 0)
                {
                    _remainingSmallAsteroidsHits--;
                    return true;
                }

                break;

            case ObstacleType.Meteorite:
                if (_remainingMeteoriteHits > 0)
                {
                    _remainingMeteoriteHits--;
                    return true;
                }

                break;
        }

        IsDeflectorAlive = false;

        return false;
    }
}