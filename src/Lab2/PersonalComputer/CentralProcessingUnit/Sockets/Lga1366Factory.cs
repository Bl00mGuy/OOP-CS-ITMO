namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Lga1366Factory : ICpuFactory
{
    public ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        return new Lga1366(cpuName, numberOfCores, coresFrequency, hasIntegratedGraphics, supportedMemoryFrequencies, thermalDesignPower, powerConsumption);
    }
}