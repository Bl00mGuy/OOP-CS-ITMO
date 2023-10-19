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

    public string? Name { get; private set; }

    public DriveConnectionType ConnectionType { get; private set; }

    public int Capacity { get; private set; }

    public int MaxSpeed { get; private set; }

    public int PowerConsumption { get; private set; }

    public SolidStateDrive Clone()
    {
        return new SolidStateDrive(
            ConnectionType,
            Capacity,
            MaxSpeed,
            PowerConsumption);
    }

    public SolidStateDrive SetSsdName(string name)
    {
        SolidStateDrive ssdClone = Clone();

        ssdClone.Name = name;

        return ssdClone;
    }

    public SolidStateDrive SetSsdConnectionType(DriveConnectionType connectionType)
    {
        SolidStateDrive ssdClone = Clone();

        ssdClone.ConnectionType = connectionType;

        return ssdClone;
    }

    public SolidStateDrive SetSsdCapacity(int capacity)
    {
        SolidStateDrive ssdClone = Clone();

        ssdClone.Capacity = capacity;

        return ssdClone;
    }

    public SolidStateDrive SetSsdMaxSpeed(int maxSpeed)
    {
        SolidStateDrive ssdClone = Clone();

        ssdClone.MaxSpeed = maxSpeed;

        return ssdClone;
    }

    public SolidStateDrive SetSsdPowerConsumption(int powerConsumption)
    {
        SolidStateDrive ssdClone = Clone();

        ssdClone.PowerConsumption = powerConsumption;

        return ssdClone;
    }
}