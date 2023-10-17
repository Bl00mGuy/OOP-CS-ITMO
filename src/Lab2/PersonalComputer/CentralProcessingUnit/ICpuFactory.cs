using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

public interface ICpuFactory
{
    ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, DdrVersion supportedMemoryVersion, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption);
}