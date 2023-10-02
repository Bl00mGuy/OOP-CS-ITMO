using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

internal class JumpEngineClassGamma : Spaceship, Entities.IEngine
{
    public string EngineName => "Jump Engine Gamma";

    public double CalculateFuelConsumption(double distance)
    {
        return 4.0 * distance * distance * MassClass;
    }

    public double StartEngine()
    {
        return 24;
    }
}