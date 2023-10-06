using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassE : IEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 20;
    private const double AccelerationFactor = 1.5;

    public string EngineName => "Impulse Engine Class E";

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}