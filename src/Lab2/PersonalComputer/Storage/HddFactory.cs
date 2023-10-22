namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class HddFactory : IStorageFactory
{
    public ISsd? CreateSsd(string? name, DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        return null;
    }

    public IHdd CreateHdd(string? name, int capacity, int spindleSpeed, int powerConsumption)
    {
        return new HardDiskDrive(name, capacity, spindleSpeed, powerConsumption);
    }
}