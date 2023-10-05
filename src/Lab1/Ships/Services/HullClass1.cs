using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class HullClass1 : IHullStrength
{
    private int _remainingSmallAsteroidsHits = 1;
    private bool _isShipAlive = true;

    public string Name => "Hull Class 1";

    public bool HullObstacle(ObstacleType obstacleType)
    {
        if (_isShipAlive == false)
        {
            return false;
        }

        if (obstacleType == ObstacleType.SmallAsteroid && _remainingSmallAsteroidsHits > 0)
        {
            _remainingSmallAsteroidsHits--;
            return true;
        }

        _isShipAlive = false;

        return false;
    }
}