using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassPhoton : IDeflector
{
    private int _remainingAntimatterFlares = 3;

    public bool DeflectObstacle(Spaceship spaceship, ObstacleType obstacleType)
    {
        if (spaceship.IsDeflectorAlive == false)
        {
            return false;
        }

        if (obstacleType == ObstacleType.AntimatterFlare && _remainingAntimatterFlares > 0)
        {
            _remainingAntimatterFlares--;
            return true;
        }

        spaceship.SetDeflectorStatus(false);

        return false;
    }
}