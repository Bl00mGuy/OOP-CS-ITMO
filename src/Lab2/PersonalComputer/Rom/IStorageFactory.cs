namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Rom;

public interface IStorageFactory
{
    ISsd? CreateSsd(DriveConnectionType connectionType, int capacity, int maxSpeed, double powerConsumptionWatt);
    IHdd? CreateHdd(int capacity, int spindleSpeed, double powerConsumptionWatt);
}