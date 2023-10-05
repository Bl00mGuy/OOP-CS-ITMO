using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SeventhTest
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 200, 100, 200)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int normalSpaceLength, int highDensityFogLength, int nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip(true);

        var normalSpace = new NormalSpace(3, 4, normalSpaceLength);
        var highDensityFogSegment = new HighDensityFog(1, highDensityFogLength);
        var nitrineParticleFog = new NitrineParticleFog(1, nitrineParticleFogLength);

        var segments = new Collection<Environment.Entities.Environment> { normalSpace, highDensityFogSegment, nitrineParticleFog };

        string expectedOutput1 = "The spaceship has been destroyed";
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