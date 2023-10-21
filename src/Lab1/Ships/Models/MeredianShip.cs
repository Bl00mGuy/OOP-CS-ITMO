using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class MeredianShip : Spaceship
{
    public MeredianShip(bool hasPhotonDeflector)
    {
        Engine = new ImpulseEngineClassE();
        Deflector = new DeflectorClassSecond(hasPhotonDeflector);
        AntiNitrineEmitter = true;
        HullStrength = new HullClassSecond();
        DimensionCategory = new RegularDimensions();
    }
}