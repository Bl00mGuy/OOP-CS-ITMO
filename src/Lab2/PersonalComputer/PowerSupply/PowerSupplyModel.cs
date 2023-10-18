namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public class PowerSupplyModel : IPowerSupply
{
    public PowerSupplyModel(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
    public string? Name { get; }
}