using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public class CpuCoolingSystem : ICoolingSystem
{
    public CpuCoolingSystem(Dimensions dimensions, IList<ICpuFactory> supportedSockets, int maxThermalDesignPower, int powerConsumption)
    {
        DimensionsOfCoolingSystem = dimensions;
        SupportedSockets = supportedSockets;
        MaxThermalDesignPower = maxThermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public Dimensions DimensionsOfCoolingSystem { get; }

    public IList<ICpuFactory> SupportedSockets { get; }

    public int MaxThermalDesignPower { get; }

    public int PowerConsumption { get; }
}