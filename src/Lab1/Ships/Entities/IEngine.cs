namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IEngine
{
    double CalculateFuelConsumption(double distance);
    double StartEngine();
}