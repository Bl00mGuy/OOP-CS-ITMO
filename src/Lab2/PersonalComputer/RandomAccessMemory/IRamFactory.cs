namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRamFactory
{
    IRam CreateRam(string? name, int numberOfRamPads, int memorySize, DdrVersion ddrVersion, int ddrFrequency, RamFormFactor formFactor, int powerConsumption);
}