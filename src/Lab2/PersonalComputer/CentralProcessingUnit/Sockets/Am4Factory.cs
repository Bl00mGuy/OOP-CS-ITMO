namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;

public class Am4Factory : ICpuFactory
{
    public ICpu CreateCpu(string cpuName, int numberOfCores, int coresFrequency, bool hasIntegratedGraphics, int supportedMemoryFrequencies, int thermalDesignPower, int powerConsumption)
    {
        return new Am4(cpuName, numberOfCores, coresFrequency, hasIntegratedGraphics, supportedMemoryFrequencies, thermalDesignPower, powerConsumption);
    }
}