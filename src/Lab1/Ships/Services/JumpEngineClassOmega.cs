using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassOmega : IJumpEngine
{
    private const int RequiredAmountOfFuelToStartTheEngine = 16;
    private const double AccelerationFactor = 3.0;

    public double MaxJumpLength => 200;

    public double CalculateFuelConsumption(double distance)
    {
        return AccelerationFactor * Math.Log(distance);
    }

    public double StartEngine()
    {
        return RequiredAmountOfFuelToStartTheEngine;
    }
}