namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

internal class JumpEngineClassGamma : Entities.IEngine
{
    public string Name => "Jump Engine Gamma";

    public double CalculateFuelConsumption(double distance)
    {
        return 4.0 * distance * distance;
    }
}