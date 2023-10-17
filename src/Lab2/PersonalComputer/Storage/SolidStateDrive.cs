namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class SolidStateDrive : ISsd
{
    public SolidStateDrive(DriveConnectionType connectionType, int capacity, int maxSpeed, double powerConsumptionWatt)
    {
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumptionWatt = powerConsumptionWatt;
    }

    public DriveConnectionType ConnectionType { get; }

    public int Capacity { get; }

    public int MaxSpeed { get; }

    public double PowerConsumptionWatt { get; }
}