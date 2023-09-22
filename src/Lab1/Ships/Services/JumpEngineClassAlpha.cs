namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

internal class JumpEngineClassAlpha : Entities.IEngine
{
    public string Name => "Jump Engine Alpha";

    public double CalculateFuelConsumption(double distance)
    {
        return 2.0 * distance;
    }
}