using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public class CpuCoolingSystemFactory : ICoolingSystemFactory
{
    public ICoolingSystem CreateCoolingSystem(Dimensions dimensions, IList<ICpuFactory> supportedSockets, int maxThermalDesignPower, int powerConsumption)
    {
        return new CpuCoolingSystem(dimensions, supportedSockets, maxThermalDesignPower, powerConsumption);
    }
}