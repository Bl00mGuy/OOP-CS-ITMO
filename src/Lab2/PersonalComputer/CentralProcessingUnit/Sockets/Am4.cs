namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Am4 : ICpu
{
    public Am4(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
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

    public Am4 SetCpuName(string name)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.Name = name;

        return cloneCpu;
    }

    public Am4 SetCpuNumberOfCores(int numberOfCores)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.NumberOfCores = numberOfCores;

        return cloneCpu;
    }

    public Am4 SetCpuCoresFrequency(int coresFrequency)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.CoresFrequency = coresFrequency;

        return cloneCpu;
    }

    public Am4 SetCpuHasIntegratedGraphics(bool hasIntegratedGraphics)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.HasIntegratedGraphics = hasIntegratedGraphics;

        return cloneCpu;
    }

    public Am4 SetCpuSupportedMemoryFrequencies(int supportedMemoryFrequencies)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.SupportedMemoryFrequencies = supportedMemoryFrequencies;

        return cloneCpu;
    }

    public Am4 SetCpuThermalDesignPower(int thermalDesignPower)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.ThermalDesignPower = thermalDesignPower;

        return cloneCpu;
    }

    public Am4 SetCpuPowerConsumption(int powerConsumption)
    {
        Am4 cloneCpu = Clone();

        cloneCpu.PowerConsumption = powerConsumption;

        return cloneCpu;
    }

    public Am4 Clone()
    {
        return new Am4(
            (string)Name.Clone(),
            NumberOfCores,
            CoresFrequency,
            HasIntegratedGraphics,
            SupportedMemoryFrequencies,
            ThermalDesignPower,
            PowerConsumption);
    }

    public bool Equally(ICpu cpu)
    {
        if (cpu is not Am4) return false;
        return true;
    }
}