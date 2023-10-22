namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class RamFactory : IRamFactory
{
    public IRam CreateRam(string? name, int numberOfRamPads, int memorySize, DdrVersion ddrVersion, int ddrFrequency, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ram(name, numberOfRamPads, memorySize, ddrVersion, ddrFrequency, formFactor, powerConsumption);
    }
}