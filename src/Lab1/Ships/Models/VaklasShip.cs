using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class VaklasShip : Spaceship
{
    public VaklasShip(bool hasPhotonDeflector)
    {
        Engine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineClassGamma();
        Deflector = new DeflectorClassFirst(hasPhotonDeflector);
        HullStrength = new HullClassSecond();
        DimensionClassCategory = 2;
    }
}