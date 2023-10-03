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
    [InlineData(10000, 10000, 0, 10, 200, 5)] // Прогулочный челнок без прыжковых двигателей
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int normalSpaceLength, int highDensityFogLength)
    {
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip();

        var normalSpaceSegment = new NormalSpace(0, 0, normalSpaceLength);
        var highDensityFogSegment = new HighDensityFog(0, highDensityFogLength);

        var segments1 = new Collection<Environment.Entities.Environment> { normalSpaceSegment, highDensityFogSegment };
        var segments2 = new Collection<Environment.Entities.Environment> { normalSpaceSegment, highDensityFogSegment };

        // Act
        Action sendSpaceship1 = () =>
        {
            Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments1);
        };

        Action sendSpaceship2 = () =>
        {
            Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments2);
        };

        // Assert
        if (initialFuelActivePlasma <= 0)
        {
            Assert.Throws<ArgumentOutOfRangeException>(sendSpaceship1);
            Assert.Throws<ArgumentOutOfRangeException>(sendSpaceship2);
        }
        else
        {
            if (fuelActivePlasmaPrice <= 0)
            {
                Assert.Throws<ArgumentException>(sendSpaceship1);
                Assert.Throws<ArgumentException>(sendSpaceship2);
            }
            else
            {
                Assert.Throws<InvalidOperationException>(sendSpaceship1);
                if (initialFuelGravitonMatter <= 0 || fuelGravitonMatterPrice <= 0)
                {
                    Assert.Throws<ArgumentException>(sendSpaceship2);
                }
                else
                {
                    Assert.Throws<InvalidOperationException>(sendSpaceship2);
                }
            }
        }
    }
}