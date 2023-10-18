namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr4 : IRam
{
    public Ddr4(int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        MemorySize = memorySize;
        DdrFrequency = ddrFrequency;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get; }
    public int DdrFrequency { get; }
    public RamFormFactor FormFactor { get; }
    public int PowerConsumption { get; }
}