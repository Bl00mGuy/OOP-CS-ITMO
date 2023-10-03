using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

internal class JumpEngineClassAlpha : Spaceship, Entities.IEngine
{
    // private double maxJumpLength = 100;
    public string EngineName => "Jump Engine Alpha";

    public double CalculateFuelConsumption(double distance)
    {
        return 2.0 * distance * MassClass;
    }

    public double StartEngine()
    {
        return 8;
    }
}