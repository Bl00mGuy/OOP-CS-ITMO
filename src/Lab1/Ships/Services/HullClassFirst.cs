using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class HullClassFirst : IHullStrength
{
    private bool _isShipAlive = true;
    public int HullSafetyMargin { get; private set; } = 315;

    public bool HullObstacle(int obstacleDamage)
    {
        if (_isShipAlive && HullSafetyMargin > 0)
        {
            HullSafetyMargin -= obstacleDamage;

            return true;
        }

        _isShipAlive = false;

        return false;
    }
}