using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassPhoton : IDeflector
{
    private int _remainingAntimatterFlares = 3;

    public string Name => "Deflector Class Photon";

    private bool IsDeflectorAlive { get; set; } = true;

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