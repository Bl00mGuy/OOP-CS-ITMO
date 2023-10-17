using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public interface ICoolingSystem
{
    Dimensions DimensionsOfCoolingSystem { get; }
    IList<ICpuFactory> SupportedSockets { get; }
    int MaxThermalDesignPower { get; }
    int PowerConsumption { get; }
}