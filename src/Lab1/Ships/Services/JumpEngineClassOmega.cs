using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

internal class JumpEngineClassOmega : Entities.IEngine
{
    public string Name => "Jump Engine Omega";

    public double CalculateFuelConsumption(double distance)
    {
        return 3.0 * Math.Log(2.0 * distance);
    }
}