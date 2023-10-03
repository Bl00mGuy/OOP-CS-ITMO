namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IJumpEngine
{
    string EngineName { get; }
    double MaxJumpLength { get; }
    double CalculateFuelConsumption(double distance);
    double StartEngine();
}