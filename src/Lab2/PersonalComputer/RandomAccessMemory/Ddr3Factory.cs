namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr3Factory : IRamFactory
{
    public IRam CreateRam(int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ddr3(memorySize, ddrFrequency, formFactor, powerConsumption);
    }
}