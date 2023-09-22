using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class DeflectorClassPhoton : IDeflector
{
    private int _remainingAntimatterFlares = 3;

    public bool IsDeflectorAlive { get; private set; } = true;
    public string Name => "Deflector Class Photon";

    public bool DeflectObstacle(ObstacleType obstacleType)
    {
        if (IsDeflectorAlive == false)
        {
            return false;
        }

        if (obstacleType == ObstacleType.AntimatterFlare && _remainingAntimatterFlares > 0)
        {
            _remainingAntimatterFlares--;
            return true;
        }

        IsDeflectorAlive = false;

        return false;
    }
}