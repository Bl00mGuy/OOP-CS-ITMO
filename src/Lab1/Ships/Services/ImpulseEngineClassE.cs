using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassE : IEngine
{
    public string EngineName => "Impulse Engine Class E";

    public double CalculateFuelConsumption(double distance)
    {
        return 1.5 * distance;
    }

    public double StartEngine()
    {
        return 20;
    }
}