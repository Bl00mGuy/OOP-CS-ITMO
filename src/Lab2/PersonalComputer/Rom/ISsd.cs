namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Rom;

public interface ISsd
{
    DriveConnectionType ConnectionType { get; }
    int Capacity { get; }
    int MaxSpeed { get; }
    double PowerConsumptionWatt { get; }
}