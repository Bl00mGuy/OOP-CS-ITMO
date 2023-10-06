using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class StellaShip : Spaceship
{
    public StellaShip(bool hasPhotonDeflector)
    {
        Name = "Stella";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassC();
        JumpEngine = new JumpEngineClassOmega();
        Deflector = new DeflectorClassFirst();
        HullStrength = new HullClassFirst();
        DimensionClassCategory = 1;
        if (hasPhotonDeflector)
        {
            PhotonDeflector = new DeflectorClassPhoton();
        }
    }
}