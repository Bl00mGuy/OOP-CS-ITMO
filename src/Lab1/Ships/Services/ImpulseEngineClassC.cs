namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassC : Entities.IEngine
{
    public string EngineName => "Impulse Engine Class C";

    public double CalculateFuelConsumption(double distance)
    {
        return 0.5 * distance;
    }

    public double StartEngine()
    {
        return 10;
    }
}