using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class PleasureShuttleShip : Spaceship
{
    public PleasureShuttleShip()
    {
        Engine = new ImpulseEngineClassC();
        HullStrength = new HullClassFirst();
        DimensionClassCategory = 1;
    }
}