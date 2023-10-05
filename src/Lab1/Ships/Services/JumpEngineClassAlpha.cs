using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassAlpha : Entities.IJumpEngine
{
    public double MaxJumpLength => (double)DistanceType.Small;
    public string EngineName => "Jump Engine Alpha";

    public double CalculateFuelConsumption(double distance)
    {
        return 2.0 * distance;
    }

    public double StartEngine()
    {
        return 8;
    }
}