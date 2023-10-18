namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class HddFactory : IStorageFactory
{
    public ISsd? CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        return null;
    }

    public IHdd CreateHdd(int capacity, int spindleSpeed, int powerConsumption)
    {
        return new HardDiskDrive(capacity, spindleSpeed, powerConsumption);
    }
}