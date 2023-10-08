using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class Deflector
{
    protected Deflector(bool hasPhotonDeflectAddition)
    {
        HasPhotonDeflectAddition = hasPhotonDeflectAddition ? new DeflectorClassPhoton() : null;
    }

    public DeflectorClassPhoton? HasPhotonDeflectAddition { get; protected set; }

    protected int DeflectorSafetyMargin { get; set; }

    public abstract bool DeflectObstacle(int obstacleDamage);
}