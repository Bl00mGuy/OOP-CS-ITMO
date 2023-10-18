namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr5Factory : IRamFactory
{
    public IRam CreateRam(int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ddr5(memorySize, ddrFrequency, formFactor, powerConsumption);
    }
}