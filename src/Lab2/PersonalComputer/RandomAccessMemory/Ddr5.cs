namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr5 : IRam
{
    public Ddr5(int numberOfRamPads, int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        NumberOfRamPads = numberOfRamPads;
        MemorySize = memorySize;
        DdrFrequency = ddrFrequency;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
    }

    public int NumberOfRamPads { get; }
    public int MemorySize { get; }
    public int DdrFrequency { get; }
    public RamFormFactor FormFactor { get; }
    public int PowerConsumption { get; }
    public string? Name { get; }
}