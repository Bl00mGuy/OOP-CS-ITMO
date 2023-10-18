namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class SsdFactory : IStorageFactory
{
    public ISsd CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        return new SolidStateDrive(connectionType, capacity, maxSpeed, powerConsumption);
    }

    public IHdd? CreateHdd(int capacity, int spindleSpeed, int powerConsumption)
    {
        return null;
    }
}