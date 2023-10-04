using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 200)] // Прогулочный челнок без прыжковых двигателей
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int highDensityFogLength)
    {
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip();

        var highDensityFogSegment = new HighDensityFog(0, highDensityFogLength);

        var segments = new Collection<Environment.Entities.Environment> { highDensityFogSegment };

        ArgumentOutOfRangeException ex1 = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        });

        ArgumentOutOfRangeException ex2 = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        });

        Assert.Contains("initialFuelActivePlasma", ex1.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("initialFuelGravitonMatter", ex1.Message, StringComparison.OrdinalIgnoreCase);

        Assert.Contains("initialFuelActivePlasma", ex2.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("initialFuelGravitonMatter", ex2.Message, StringComparison.OrdinalIgnoreCase);
    }
}