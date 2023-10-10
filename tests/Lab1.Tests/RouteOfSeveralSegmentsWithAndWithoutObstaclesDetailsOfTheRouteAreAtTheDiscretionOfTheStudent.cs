using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteOfSeveralSegmentsWithAndWithoutObstaclesDetailsOfTheRouteAreAtTheDiscretionOfTheStudent
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 300, 100, 200, 3, 4, 1, 1)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double normalSpaceLength, double highDensityFogLength, double nitrineParticleFogLength, int smallAsteroidsCount, int meteoritesCount, int antimatterFlaresCount, int spaceWhalesCount)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip(true);

        var normalSpace = new NormalSpace(smallAsteroidsCount, meteoritesCount, normalSpaceLength);
        var highDensityFogSegment = new HighDensityFog(antimatterFlaresCount, highDensityFogLength);
        var nitrineParticleFog = new NitrineParticleFog(spaceWhalesCount, nitrineParticleFogLength);

        var segments = new Collection<Environments> { normalSpace, highDensityFogSegment, nitrineParticleFog };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.ShipDestroyed;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

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