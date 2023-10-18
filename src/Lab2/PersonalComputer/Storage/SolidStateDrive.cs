namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class SolidStateDrive : ISsd
{
    public SolidStateDrive(DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public DriveConnectionType ConnectionType { get; }

    public int Capacity { get; }

    public int MaxSpeed { get; }

    public int PowerConsumption { get; }

    public string? Name { get; }
}