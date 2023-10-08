namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public enum VoyageErrorType
{
    NoError,
    EmptyTank,
    FuelNotFree,
    NoSegments,
    MissingRequiredEngine,
    MissingRequiredJumpEngine,
    MaxJumpLengthExceeded,
    NotEnoughFuel,
    CrewDied,
    ShipDestroyed,
}