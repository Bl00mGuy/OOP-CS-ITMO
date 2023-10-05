using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, (double)DistanceType.Medium)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new AvgurShip(false);
        var spaceship2 = new StellaShip(false);

        var highDensityFogSegment = new HighDensityFog(0, highDensityFogLength);

        var segments = new Collection<Environment.Entities.Environment> { highDensityFogSegment };

        const string expectedOutput1 = "Spaceship doesn't have a required jump engine max jump length!";
        const string expectedOutput2 = "The spacecraft has successfully complete voyage";

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1());
        Assert.Equal(expectedOutput2, SendSpaceship2());
        return;

        // Act
        string SendSpaceship1()
        {
            return Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship2()
        {
            return Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }
    }
}