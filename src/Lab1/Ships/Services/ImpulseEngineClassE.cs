using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class ImpulseEngineClassE : IEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 20;
    private const double AccelerationFactor = 1.5;

    public double CalculateFuelConsumption(double distance)
    {
        return Math.Exp(AccelerationFactor) * distance;
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}