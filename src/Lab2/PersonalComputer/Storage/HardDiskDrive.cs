namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class HardDiskDrive : IHdd
{
    public HardDiskDrive(int capacity, int spindleSpeed, int powerConsumption)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }

    public int SpindleSpeed { get; }

    public int PowerConsumption { get; }

    public string? Name { get; }
}