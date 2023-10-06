using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassC : IEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 10;
    private const double AccelerationFactor = 0.5;

    public string EngineName => "Impulse Engine Class C";

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}