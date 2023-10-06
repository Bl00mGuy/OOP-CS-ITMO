using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassGamma : IJumpEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 24;
    private const double AccelerationFactor = 4.0;

    public double MaxJumpLength => (double)DistanceType.Big;
    public string EngineName => "Jump Engine Gamma";

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * distance * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}