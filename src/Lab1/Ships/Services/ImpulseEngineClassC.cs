namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class ImpulseEngineClassC : Entities.IEngine
{
    public string Name => "Impulse Engine Class C";

    public double CalculateFuelConsumption(double distance)
    {
        return 0.5 * distance;
    }
}