using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class AvgurShip : Entities.Spaceship
{
    public AvgurShip(bool hasPhotonDeflector)
    {
        Name = "Avgur";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineClassAlpha();
        Deflector = new DeflectorClass3();
        HullStrength = new HullClass3();
        MassClass = 3;
        if (hasPhotonDeflector)
        {
            PhotonDeflector = new DeflectorClassPhoton();
        }
    }
}