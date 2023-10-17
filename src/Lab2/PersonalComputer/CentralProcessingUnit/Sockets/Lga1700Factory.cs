using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Lga1700Factory : ICpuFactory
{
    public ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, DdrVersion supportedMemoryVersion, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        return new Lga1700(cpuName, numberOfCores, coresFrequency, hasIntegratedGraphics, supportedMemoryVersion, supportedMemoryFrequencies, thermalDesignPower, powerConsumption);
    }
}