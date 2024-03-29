using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class DeflectorClassThird : Deflector
{
    private const int InitialDeflectorSafetyMargin = 21010;
    private bool _isDeflectorAlive = true;

    public DeflectorClassThird(bool hasPhotonDeflectAddition)
        : base(hasPhotonDeflectAddition)
    {
        DeflectorSafetyMargin = InitialDeflectorSafetyMargin;
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