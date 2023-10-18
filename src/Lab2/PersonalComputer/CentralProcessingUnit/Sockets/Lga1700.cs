namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Lga1700 : ICpu
{
    public Lga1700(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        Name = cpuName;
        NumberOfCores = numberOfCores;
        CoresFrequency = coresFrequency;
        HasIntegratedGraphics = hasIntegratedGraphics;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public int NumberOfCores { get; }

    public int CoresFrequency { get; }

    public bool HasIntegratedGraphics { get; }

    public int SupportedMemoryFrequencies { get; }

    public int ThermalDesignPower { get; }

    public int PowerConsumption { get; }
}