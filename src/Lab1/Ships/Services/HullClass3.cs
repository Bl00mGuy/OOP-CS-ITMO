using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class HullClass3 : Entities.IHullStrength
{
    private int _remainingSmallAsteroidsHits = 20;
    private int _remainingMeteoriteHits = 5;
    private bool _isShipAlive = true;

    public string Name => "Hull Class 2";

    public bool HullObstacle(ObstacleType obstacleType)
    {
        if (_isShipAlive == false)
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

        _isShipAlive = false;

        return false;
    }
}