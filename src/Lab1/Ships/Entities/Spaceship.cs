namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Spaceship
{
    public IImpulseEngine? Engine { get; protected init; }
    public IJumpEngine? JumpEngine { get; protected init; }
    public Deflector? Deflector { get; protected init; }
    public bool? AntiNitrineEmitter { get; protected init; }
    public IHullStrength? HullStrength { get; protected init; }
    public IDimensionCategory? DimensionCategory { get; protected init; }
}