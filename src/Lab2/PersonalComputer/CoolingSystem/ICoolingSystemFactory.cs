using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public interface ICoolingSystemFactory
{
    ICoolingSystem CreateCoolingSystem(Dimensions dimensions, IList<ICpu> supportedSockets, int maxThermalDesignPower, int powerConsumption);
}