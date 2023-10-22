namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class SsdFactory : IStorageFactory
{
    public ISsd CreateSsd(string? name, DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        return new SolidStateDrive(name, connectionType, capacity, maxSpeed, powerConsumption);
    }

    public IHdd? CreateHdd(string? name, int capacity, int spindleSpeed, int powerConsumption)
    {
        return null;
    }
}