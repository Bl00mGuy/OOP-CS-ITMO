namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface IStorageFactory
{
    ISsd? CreateSsd(string? name, DriveConnectionType connectionType, int capacity, int maxSpeed, int powerConsumption);
    IHdd? CreateHdd(string? name, int capacity, int spindleSpeed, int powerConsumption);
}