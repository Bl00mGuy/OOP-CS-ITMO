using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class StellaShip : Entities.Spaceship
{
    public StellaShip()
    {
        Name = "Stella";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassC();
        JumpEngine = new JumpEngineClassOmega();
        Deflector = new DeflectorClass1();
        HullStrength = new HullClass1();
        MassClass = 1;
    }
}