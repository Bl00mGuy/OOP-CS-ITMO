namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public class PowerSupplyFactory : IPowerSupplyFactory
{
    public IPowerSupply CreatePowerSupply(string? name, int peakLoad)
    {
        return new PowerSupplyModel(name, peakLoad);
    }
}