namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public class PowerSupplyModel : PowerSupply
{
    public PowerSupplyModel(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    private int PeakLoad { get; }

    public override int GetPower()
    {
        return PeakLoad;
    }

    public override ValidationStatus ValidatePower(int requiredPower)
    {
        return PeakLoad switch
        {
            _ when PeakLoad < requiredPower => ValidationStatus.InsufficientPower,
            _ when PeakLoad > requiredPower => ValidationStatus.ExceedsRecommendedPower,
            _ => ValidationStatus.Valid,
        };
    }
}