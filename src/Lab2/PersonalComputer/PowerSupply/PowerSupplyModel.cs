namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public class PowerSupplyModel : IPowerSupply
{
    public PowerSupplyModel(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public string? Name { get; private set; }
    public int PeakLoad { get; private set; }

    public PowerSupplyModel Clone()
    {
        return new PowerSupplyModel(
            PeakLoad);
    }

    public PowerSupplyModel SetPowerSupplyName(string name)
    {
        PowerSupplyModel powerSupplyClone = Clone();

        powerSupplyClone.Name = name;

        return powerSupplyClone;
    }

    public PowerSupplyModel SetPowerSupplyPeakLoad(int peakLoad)
    {
        PowerSupplyModel powerSupplyClone = Clone();

        powerSupplyClone.PeakLoad = peakLoad;

        return powerSupplyClone;
    }
}