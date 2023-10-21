using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public class CpuCoolingSystemFactory : ICoolingSystemFactory
{
    public ICoolingSystem CreateCoolingSystem(string? name, Dimensions dimensions, IList<ICpu> supportedSockets, int maxThermalDesignPower, int powerConsumption)
    {
        return new CpuCoolingSystem(name, dimensions, supportedSockets, maxThermalDesignPower, powerConsumption);
    }
}