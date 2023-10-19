namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Lga1366 : ICpu
{
    public Lga1366(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        Name = cpuName;
        NumberOfCores = numberOfCores;
        CoresFrequency = coresFrequency;
        HasIntegratedGraphics = hasIntegratedGraphics;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }

    public int NumberOfCores { get; private set; }

    public int CoresFrequency { get; private set; }

    public bool HasIntegratedGraphics { get; private set; }

    public int SupportedMemoryFrequencies { get; private set; }

    public int ThermalDesignPower { get; private set; }

    public int PowerConsumption { get; private set; }

    public Lga1366 SetCpuName(string name)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.Name = name;

        return cloneCpu;
    }

    public Lga1366 SetCpuNumberOfCores(int numberOfCores)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.NumberOfCores = numberOfCores;

        return cloneCpu;
    }

    public Lga1366 SetCpuCoresFrequency(int coresFrequency)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.CoresFrequency = coresFrequency;

        return cloneCpu;
    }

    public Lga1366 SetCpuHasIntegratedGraphics(bool hasIntegratedGraphics)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.HasIntegratedGraphics = hasIntegratedGraphics;

        return cloneCpu;
    }

    public Lga1366 SetCpuSupportedMemoryFrequencies(int supportedMemoryFrequencies)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.SupportedMemoryFrequencies = supportedMemoryFrequencies;

        return cloneCpu;
    }

    public Lga1366 SetCpuThermalDesignPower(int thermalDesignPower)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.ThermalDesignPower = thermalDesignPower;

        return cloneCpu;
    }

    public Lga1366 SetCpuPowerConsumption(int powerConsumption)
    {
        Lga1366 cloneCpu = Clone();

        cloneCpu.PowerConsumption = powerConsumption;

        return cloneCpu;
    }

    public Lga1366 Clone()
    {
        return new Lga1366(
            (string)Name.Clone(),
            NumberOfCores,
            CoresFrequency,
            HasIntegratedGraphics,
            SupportedMemoryFrequencies,
            ThermalDesignPower,
            PowerConsumption);
    }
}