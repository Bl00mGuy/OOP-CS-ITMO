namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr5Factory : IRamFactory
{
    public IRam CreateRam(int numberOfRamPads, int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ddr5(numberOfRamPads, memorySize, ddrFrequency, formFactor, powerConsumption);
    }
}