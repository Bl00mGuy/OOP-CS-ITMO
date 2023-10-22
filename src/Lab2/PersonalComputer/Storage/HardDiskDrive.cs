namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class HardDiskDrive : IHdd
{
    public HardDiskDrive(string? name, int capacity, int spindleSpeed, int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }

    public int Capacity { get; private set; }

    public int SpindleSpeed { get; private set; }

    public int PowerConsumption { get; private set; }

    public HardDiskDrive Clone()
    {
        return new HardDiskDrive(
            Name,
            Capacity,
            SpindleSpeed,
            PowerConsumption);
    }

    public HardDiskDrive SetHddName(string name)
    {
        HardDiskDrive hddClone = Clone();

        hddClone.Name = name;

        return hddClone;
    }

    public HardDiskDrive SetHddCapacity(int capacity)
    {
        HardDiskDrive hddClone = Clone();

        hddClone.Capacity = capacity;

        return hddClone;
    }

    public HardDiskDrive SetHddSpindleSpeed(int spindleSpeed)
    {
        HardDiskDrive hddClone = Clone();

        hddClone.SpindleSpeed = spindleSpeed;

        return hddClone;
    }

    public HardDiskDrive SetHddPowerConsumption(int powerConsumption)
    {
        HardDiskDrive hddClone = Clone();

        hddClone.PowerConsumption = powerConsumption;

        return hddClone;
    }
}