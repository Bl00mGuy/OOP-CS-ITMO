namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Rom;

public class HddFactory : IStorageFactory
{
    public ISsd? CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, double powerConsumptionWatt)
    {
        return null;
    }

    public IHdd CreateHdd(int capacity, int spindleSpeed, double powerConsumptionWatt)
    {
        return new HardDiskDrive(capacity, spindleSpeed, powerConsumptionWatt);
    }
}