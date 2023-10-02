using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

internal class JumpEngineClassOmega : Spaceship, Entities.IEngine
{
    public string EngineName => "Jump Engine Omega";

    public double CalculateFuelConsumption(double distance)
    {
        return 3.0 * Math.Log(2.0 * distance) * MassClass;
    }

    public double StartEngine()
    {
        return 16;
    }
}