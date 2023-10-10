namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IImpulseEngine
{
    double CalculateFuelConsumption(double distance);
    double StartEngine();
}