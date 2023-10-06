using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassAlpha : IJumpEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 8;
    private const double AccelerationFactor = 1.5;

    public double MaxJumpLength => (double)DistanceType.Small;
    public string EngineName => "Jump Engine Alpha";

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}