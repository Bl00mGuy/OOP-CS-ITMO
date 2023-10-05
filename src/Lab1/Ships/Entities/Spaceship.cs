using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class Spaceship
{
    public string? Name { get; protected set; }
    public bool? IsShipAlive { get; protected set; }
    public bool? IsCrewAlive { get; protected set; }
    public IEngine? Engine { get; protected set; }
    public IJumpEngine? JumpEngine { get; protected set; }
    public IDeflector? Deflector { get; protected set; }
    public IDeflector? PhotonDeflector { get; protected set; }
    public bool? AntiNitrineEmitter { get; protected set; }
    public IHullStrength? HullStrength { get; protected set; }
    public int MassClass { get; protected set; }
    public Route? Route { get; private set; }

    public void SetShipStatus(bool isAlive)
    {
        IsCrewAlive = isAlive;
    }

    public void SetCrewStatus(bool isAlive)
    {
        IsCrewAlive = isAlive;
    }

    public void SetRoute(Route route)
    {
        Route = route;
    }
}