namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class RamFactory : IRamFactory
{
    public IRam CreateRam(int numberOfRamPads, int memorySize, DdrVersion ddrVersion, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ram(numberOfRamPads, memorySize, ddrVersion, ddrFrequency, formFactor, powerConsumption);
    }
}