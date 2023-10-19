using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public interface ICoolingSystem : IComponent
{
    Dimensions DimensionsOfCoolingSystem { get; }
    IList<ICpu> SupportedSockets { get; }
    int MaxThermalDesignPower { get; }
    int PowerConsumption { get; }
}