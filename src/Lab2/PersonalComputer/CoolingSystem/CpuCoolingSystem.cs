using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;

public class CpuCoolingSystem : ICoolingSystem
{
    public CpuCoolingSystem(Dimensions dimensions, IList<ICpu> supportedSockets, int maxThermalDesignPower, int powerConsumption)
    {
        DimensionsOfCoolingSystem = dimensions;
        SupportedSockets = supportedSockets;
        MaxThermalDesignPower = maxThermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }

    public Dimensions DimensionsOfCoolingSystem { get; private set; }

    public IList<ICpu> SupportedSockets { get; private set; }

    public int MaxThermalDesignPower { get; private set; }

    public int PowerConsumption { get; private set; }

    public CpuCoolingSystem Clone()
    {
        return new CpuCoolingSystem(
        DimensionsOfCoolingSystem,
        SupportedSockets,
        MaxThermalDesignPower,
        PowerConsumption);
    }

    public CpuCoolingSystem SetCoolingSystemDimensions(Dimensions coolingSystemDimensions)
    {
        CpuCoolingSystem coolingSystemClone = Clone();

        coolingSystemClone.DimensionsOfCoolingSystem = coolingSystemDimensions;

        return coolingSystemClone;
    }

    public CpuCoolingSystem SetCoolingSystemSupportedSockets(IList<ICpu> coolingSystemSupportedSockets)
    {
        CpuCoolingSystem coolingSystemClone = Clone();

        coolingSystemClone.SupportedSockets = coolingSystemSupportedSockets;

        return coolingSystemClone;
    }

    public CpuCoolingSystem SetCoolingSystemMaxThermalDesignPower(int coolingSystemMaxThermalDesignPower)
    {
        CpuCoolingSystem coolingSystemClone = Clone();

        coolingSystemClone.MaxThermalDesignPower = coolingSystemMaxThermalDesignPower;

        return coolingSystemClone;
    }

    public CpuCoolingSystem SetCoolingSystemPowerConsumption(int coolingSystemPowerConsumption)
    {
        CpuCoolingSystem coolingSystemClone = Clone();

        coolingSystemClone.PowerConsumption = coolingSystemPowerConsumption;

        return coolingSystemClone;
    }
}