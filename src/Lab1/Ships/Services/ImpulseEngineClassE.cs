namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ImpulseEngineClassE : Entities.IEngine
{
    public string Name => "Impulse Engine Class E";

    public double CalculateFuelConsumption(double distance)
    {
        return 1.5 * distance;
    }
}