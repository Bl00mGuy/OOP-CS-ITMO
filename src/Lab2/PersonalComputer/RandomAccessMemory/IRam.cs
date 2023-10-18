namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRam
{
    int MemorySize { get; }
    int DdrFrequency { get; }
    RamFormFactor FormFactor { get; }
    int PowerConsumption { get; }
}