using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassC : IImpulseEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 10;
    private const double AccelerationFactor = 0.5;

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}