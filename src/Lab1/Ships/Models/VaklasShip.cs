using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class VaklasShip : Entities.Spaceship
{
    public VaklasShip(bool hasPhotonDeflector)
    {
        Name = "Vaklas";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineClassGamma();
        Deflector = new DeflectorClass1();
        HullStrength = new HullClass2();
        MassClass = 2;
        if (hasPhotonDeflector)
        {
            PhotonDeflector = new DeflectorClassPhoton();
        }
    }
}