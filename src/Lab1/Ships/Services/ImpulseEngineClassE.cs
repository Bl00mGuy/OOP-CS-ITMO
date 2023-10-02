using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassE : Spaceship, Entities.IEngine
{
    public string EngineName => "Impulse Engine Class E";

    public double CalculateFuelConsumption(double distance)
    {
        return 1.5 * distance * MassClass;
    }

    public double StartEngine()
    {
        return 20;
    }
}