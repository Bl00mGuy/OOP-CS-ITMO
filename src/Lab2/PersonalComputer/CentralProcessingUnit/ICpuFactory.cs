using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

public interface ICpuFactory
{
    ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, IRam supportedMemoryVersion, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption);
}