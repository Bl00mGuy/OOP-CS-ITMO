using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class MeredianShip : Spaceship
{
    public MeredianShip(bool hasPhotonDeflector)
    {
        Name = "Meredian";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassE();
        Deflector = new DeflectorClass2();
        AntiNitrineEmitter = true;
        HullStrength = new HullClass2();
        MassClass = 2;
        if (hasPhotonDeflector)
        {
            PhotonDeflector = new DeflectorClassPhoton();
        }
    }
}