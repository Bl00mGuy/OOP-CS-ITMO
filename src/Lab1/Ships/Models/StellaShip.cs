using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class StellaShip : Spaceship
{
    public StellaShip(bool hasPhotonDeflector)
    {
        Engine = new ImpulseEngineClassC();
        JumpEngine = new JumpEngineClassOmega();
        Deflector = new DeflectorClassFirst(hasPhotonDeflector);
        HullStrength = new HullClassFirst();
        DimensionClassCategory = 1;
    }
}