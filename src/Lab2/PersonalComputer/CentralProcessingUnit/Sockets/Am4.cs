using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Am4 : ICpu
{
    public Am4(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, DdrVersion supportedMemoryVersion, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        CpuName = cpuName;
        NumberOfCores = numberOfCores;
        CoresFrequency = coresFrequency;
        HasIntegratedGraphics = hasIntegratedGraphics;
        SupportedMemoryVersion = supportedMemoryVersion;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string CpuName { get; }

    public int NumberOfCores { get; }

    public int CoresFrequency { get; }

    public bool HasIntegratedGraphics { get; }

    public DdrVersion SupportedMemoryVersion { get; }

    public int SupportedMemoryFrequencies { get; }

    public int ThermalDesignPower { get; }

    public int PowerConsumption { get; }
}