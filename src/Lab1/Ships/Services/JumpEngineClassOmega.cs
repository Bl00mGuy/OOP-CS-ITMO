using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class JumpEngineClassOmega : IJumpEngine
{
    public double MaxJumpLength => (double)DistanceType.Medium;
    public string EngineName => "Jump Engine Omega";

    public double CalculateFuelConsumption(double distance)
    {
        return 3.0 * Math.Log(2.0 * distance);
    }

    public double StartEngine()
    {
        return 16;
    }
}