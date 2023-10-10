using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class AvgurShip : Spaceship
{
    public AvgurShip(bool hasPhotonDeflector)
    {
        Engine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineClassAlpha();
        Deflector = new DeflectorClassThird(hasPhotonDeflector);
        HullStrength = new HullClassThird();
        DimensionCategory = new HeavyDimensions();
    }
}