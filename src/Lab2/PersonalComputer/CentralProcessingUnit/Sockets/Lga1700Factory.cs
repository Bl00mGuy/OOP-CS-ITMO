namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Lga1700Factory : ICpuFactory
{
    public ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        return new Lga1700(cpuName, numberOfCores, coresFrequency, hasIntegratedGraphics, supportedMemoryFrequencies, thermalDesignPower, powerConsumption);
    }
}