using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class PleasureShuttleShip : Entities.Spaceship
{
    public PleasureShuttleShip()
    {
        Name = "Shuttle";
        IsShipAlive = true;
        IsCrewAlive = true;
        Engine = new ImpulseEngineClassC();
        HullStrength = new HullClass1();
        MassClass = 1;
    }
}