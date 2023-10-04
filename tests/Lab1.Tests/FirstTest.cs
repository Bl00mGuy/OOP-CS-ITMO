using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
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

        string expectedOutput1 = "Spaceship doesn't have a required jump engine!";
        string expectedOutput2 = "Spaceship doesn't have a required jump engine max jump length!";

        // Act and Assert
        string SendSpaceship1()
        {
            return Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship2()
        {
            return Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        Assert.Equal(expectedOutput1, SendSpaceship1());
        Assert.Equal(expectedOutput2, SendSpaceship2());
    }
}