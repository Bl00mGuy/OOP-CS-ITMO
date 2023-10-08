using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassThird : Deflector
{
    private bool _isDeflectorAlive = true;

    public DeflectorClassThird(bool hasPhotonDeflectAddition)
        : base(hasPhotonDeflectAddition)
    {
        DeflectorSafetyMargin = 21010;
    }

    public override bool DeflectObstacle(int obstacleDamage)
    {
        if (_isDeflectorAlive && DeflectorSafetyMargin > 0)
        {
            DeflectorSafetyMargin -= obstacleDamage;

            return true;
        }

        _isDeflectorAlive = false;

        return false;
    }
}