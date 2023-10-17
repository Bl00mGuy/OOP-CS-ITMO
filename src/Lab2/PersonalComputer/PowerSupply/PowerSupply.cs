namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public abstract class PowerSupply
{
    public abstract int GetPower();
    public abstract ValidationStatus ValidatePower(int requiredPower);
}