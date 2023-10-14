using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class Environments
{
    protected Environments(double lengthOfEnvironment)
    {
        LengthOfEnvironment = lengthOfEnvironment;
        Obstacles = new List<Obstacle>();
    }

    public double LengthOfEnvironment { get; private init; }

    protected IList<Obstacle> Obstacles { get; private init; }

    public abstract VoyageOutcomeType ShipEnterSphere(Spaceship spaceship);
}