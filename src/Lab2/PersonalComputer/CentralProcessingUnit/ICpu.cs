using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

public interface ICpu : IComponent
{
    int NumberOfCores { get; }
    int CoresFrequency { get; }
    bool HasIntegratedGraphics { get; }
    int SupportedMemoryFrequencies { get; }
    int ThermalDesignPower { get; }
    int PowerConsumption { get; }
    bool Equally(ICpu cpu);
}