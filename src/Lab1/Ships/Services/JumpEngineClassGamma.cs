namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

internal class JumpEngineClassGamma : Entities.IJumpEngine
{
    public double MaxJumpLength => 300;
    public string EngineName => "Jump Engine Gamma";

    public double CalculateFuelConsumption(double distance)
    {
        return 4.0 * distance * distance;
    }

    public double StartEngine()
    {
        return 24;
    }
}