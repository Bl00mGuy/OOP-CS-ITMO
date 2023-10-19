using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public class CpuCoolingSystemFactory : ICoolingSystemFactory
{
    public ICoolingSystem CreateCoolingSystem(Dimensions dimensions, IList<ICpu> supportedSockets, int maxThermalDesignPower, int powerConsumption)
    {
        return new CpuCoolingSystem(dimensions, supportedSockets, maxThermalDesignPower, powerConsumption);
    }
}