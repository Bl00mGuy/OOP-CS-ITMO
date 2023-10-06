using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassThird : IDeflector
{
    private int _remainingSmallAsteroidsHits = 40;
    private int _remainingMeteoriteHits = 10;
    private int _remainingSpaceWhaleHits = 1;

    public bool DeflectObstacle(Spaceship spaceship, ObstacleType obstacleType)
    {
        if (spaceship.IsDeflectorAlive == false)
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

            case ObstacleType.SpaceWhale:
                if (_remainingSpaceWhaleHits > 0)
                {
                    _remainingSpaceWhaleHits--;
                    return true;
                }

                break;
        }

        spaceship.SetDeflectorStatus(false);

        return false;
    }
}