namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface IStorageFactory
{
    ISsd? CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption);
    IHdd? CreateHdd(int capacity, int spindleSpeed, int powerConsumption);
}