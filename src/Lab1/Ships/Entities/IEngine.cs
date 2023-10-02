namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IEngine
{
    string EngineName { get; }
    double CalculateFuelConsumption(double distance);
    double StartEngine();
}