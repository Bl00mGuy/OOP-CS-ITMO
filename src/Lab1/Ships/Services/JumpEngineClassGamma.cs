using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassGamma : Entities.IJumpEngine
{
    public double MaxJumpLength => (double)DistanceType.Big;
    public string EngineName => "Jump Engine Gamma";

    public double CalculateFuelConsumption(double distance)
    {
        return 4.0 * distance * distance;
    }

    public double StartEngine()
    {
        return 24;
    }
}