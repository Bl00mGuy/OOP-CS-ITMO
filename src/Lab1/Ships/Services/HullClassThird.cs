using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class HullClassThird : IHullStrength
{
    private const int InitialHullSafetyMargin = 4305;
    private int _hullSafetyMargin = InitialHullSafetyMargin;
    private bool _isShipAlive = true;

    public bool HullObstacle(int obstacleDamage)
    {
        if (_isShipAlive && _hullSafetyMargin > 0)
        {
            _hullSafetyMargin -= obstacleDamage;

            return true;
        }

        _isShipAlive = false;

        return false;
    }
}