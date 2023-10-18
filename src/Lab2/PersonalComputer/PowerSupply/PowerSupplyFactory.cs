namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public class PowerSupplyFactory : IPowerSupplyFactory
{
    public IPowerSupply CreatePowerSupply(int peakLoad)
    {
        return new PowerSupplyModel(peakLoad);
    }
}