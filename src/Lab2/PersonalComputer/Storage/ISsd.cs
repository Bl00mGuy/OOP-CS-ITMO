namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface ISsd
{
    DriveConnectionType ConnectionType { get; }
    int Capacity { get; }
    int MaxSpeed { get; }
    double PowerConsumptionWatt { get; }
}