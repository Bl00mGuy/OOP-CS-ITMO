using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

public interface ICpu
{
    string CpuName { get; }
    int NumberOfCores { get; }
    int CoresFrequency { get; }
    bool HasIntegratedGraphics { get; }
    DdrVersion SupportedMemoryVersion { get; }
    int SupportedMemoryFrequencies { get; }
    int ThermalDesignPower { get; }
    int PowerConsumption { get; }
}