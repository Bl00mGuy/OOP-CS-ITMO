namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public interface IPowerSupplyFactory
{
    IPowerSupply CreatePowerSupply(string? name, int peakLoad);
}