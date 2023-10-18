using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRam : IComponent
{
    int NumberOfRamPads { get; }
    int MemorySize { get; }
    int DdrFrequency { get; }
    RamFormFactor FormFactor { get; }
    int PowerConsumption { get; }
}