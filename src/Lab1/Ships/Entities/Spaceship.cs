namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Spaceship
{
    public IEngine? Engine { get; protected init; }
    public IJumpEngine? JumpEngine { get; protected init; }
    public Deflector? Deflector { get; protected init; }
    public bool? AntiNitrineEmitter { get; protected init; }
    public IHullStrength? HullStrength { get; protected init; }
    public int DimensionClassCategory { get; protected init; }
}