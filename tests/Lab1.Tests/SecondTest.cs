using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTest
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, (int)DistanceType.Small)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new VaklasShip(false);
        var spaceship2 = new VaklasShip(true);
        var highDensityFogSegment = new HighDensityFog(1, highDensityFogLength);

        var segments = new Collection<Environment.Entities.Environment> { highDensityFogSegment };

        string expectedOutput1 = "The ship's crew died";
        string expectedOutput2 = "The spacecraft has successfully complete voyage";

        // Act
        string SendSpaceship1()
        {
            return Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship2()
        {
            return Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1());
        Assert.Equal(expectedOutput2, SendSpaceship2());
    }
}