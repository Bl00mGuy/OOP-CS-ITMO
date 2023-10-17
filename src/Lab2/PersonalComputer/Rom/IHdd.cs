namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Rom;

public interface IHdd
{
    int Capacity { get; }
    int SpindleSpeed { get; }
    double PowerConsumptionWatt { get; }
}