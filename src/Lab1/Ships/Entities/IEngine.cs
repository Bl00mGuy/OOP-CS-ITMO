namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IEngine
{
    string Name { get; }
    double CalculateFuelConsumption(double distance);
}