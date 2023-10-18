namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRamFactory
{
    IRam CreateRam(int numberOfRamPads, int memorySize, int ddrFrequency, RamFormFactor formFactor, int powerConsumption);
}