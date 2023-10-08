using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SeventhTest
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 300, 100, 200)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double normalSpaceLength, double highDensityFogLength, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip(true);

        var normalSpace = new NormalSpace(3, 4, normalSpaceLength);
        var highDensityFogSegment = new HighDensityFog(1, highDensityFogLength);
        var nitrineParticleFog = new NitrineParticleFog(1, nitrineParticleFogLength);

        var segments = new Collection<Environments> { normalSpace, highDensityFogSegment, nitrineParticleFog };

        // const string expectedOutput1 = "The spaceship has been destroyed";
        // const string expectedOutput2 = "The spacecraft has successfully complete voyage";
        const VoyageErrorType expectedOutput1 = VoyageErrorType.ShipDestroyed;
        const VoyageErrorType expectedOutput2 = VoyageErrorType.NoError;

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1().ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, SendSpaceship2().ResultOfTheSpaceshipVoyage);
        return;

        // Act
        Route SendSpaceship1()
        {
            var route1 = new Route(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
            return route1;
        }

        Route SendSpaceship2()
        {
            var route2 = new Route(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
            return route2;
        }
    }
}