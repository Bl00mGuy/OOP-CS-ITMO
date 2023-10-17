namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class HardDiskDrive : IHdd
{
    public HardDiskDrive(int capacity, int spindleSpeed, double powerConsumptionWatt)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumptionWatt = powerConsumptionWatt;
    }

    public int Capacity { get; }

    public int SpindleSpeed { get; }

    public double PowerConsumptionWatt { get; }
}