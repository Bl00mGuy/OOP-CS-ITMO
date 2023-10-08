namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IJumpEngine
{
    double MaxJumpLength { get; }
    double CalculateFuelConsumption(double distance);
    double StartEngine();
}