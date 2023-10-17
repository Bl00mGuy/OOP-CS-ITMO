namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public abstract class RamFormFactor
{
    protected RamFormFactor(int memorySize, int powerConsumption)
    {
        MemorySize = memorySize;
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get; }

    public int PowerConsumption { get; }
}