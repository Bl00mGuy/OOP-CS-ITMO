using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

internal class JumpEngineClassOmega : Entities.IJumpEngine
{
    public double MaxJumpLength => 200;
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