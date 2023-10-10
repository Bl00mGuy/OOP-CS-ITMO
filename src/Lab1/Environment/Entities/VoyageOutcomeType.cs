namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public enum VoyageOutcomeType
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