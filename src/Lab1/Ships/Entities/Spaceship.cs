using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Spaceship
{
    public string? Name { get; protected set; }
    public bool? IsShipAlive { get; protected init; }
    public bool? IsCrewAlive { get; protected set; }
    public IEngine? Engine { get; protected init; }
    public IJumpEngine? JumpEngine { get; protected init; }
    public IDeflector? Deflector { get; protected init; }
    public IDeflector? PhotonDeflector { get; protected init; }
    public bool? AntiNitrineEmitter { get; protected init; }
    public IHullStrength? HullStrength { get; protected init; }
    public int MassClass { get; protected init; }
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