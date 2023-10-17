namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public abstract class PowerSupplyFactory
{
    public abstract PowerSupply CreatePowerSupply(int peakLoad);
}