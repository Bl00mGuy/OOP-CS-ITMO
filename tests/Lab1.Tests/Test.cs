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
    [InlineData(10000, 10000, 1, 1, 200)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip();

        var highDensityFogSegment = new HighDensityFog(0, highDensityFogLength);

        var segments = new Collection<Environment.Entities.Environment> { highDensityFogSegment };

        // Act and Assert
        void SendSpaceship1()
        {
            Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        void SendSpaceship2()
        {
            Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        if (initialFuelActivePlasma < 0 || initialFuelGravitonMatter < 0)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SendSpaceship1());
            Assert.Throws<ArgumentOutOfRangeException>(() => SendSpaceship2());
        }
        else
        {
            if (fuelActivePlasmaPrice <= 0)
            {
                Assert.Throws<ArgumentException>(() => SendSpaceship1());
                Assert.Throws<ArgumentException>(() => SendSpaceship2());
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() => SendSpaceship1());
                if (initialFuelGravitonMatter <= 0 || fuelGravitonMatterPrice <= 0)
                {
                    Assert.Throws<ArgumentException>(() => SendSpaceship2());
                }
                else
                {
                    Assert.Throws<InvalidOperationException>(() => SendSpaceship2());
                }
            }
        }
    }
}