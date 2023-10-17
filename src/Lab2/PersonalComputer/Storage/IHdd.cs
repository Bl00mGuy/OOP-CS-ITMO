namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface IHdd
{
    int Capacity { get; }
    int SpindleSpeed { get; }
    double PowerConsumptionWatt { get; }
}