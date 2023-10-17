namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public class SsdFactory : IStorageFactory
{
    public ISsd CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, double powerConsumptionWatt)
    {
        return new SolidStateDrive(connectionType, capacity, maxSpeed, powerConsumptionWatt);
    }

    public IHdd? CreateHdd(int capacity, int spindleSpeed, double powerConsumptionWatt)
    {
        return null;
    }
}