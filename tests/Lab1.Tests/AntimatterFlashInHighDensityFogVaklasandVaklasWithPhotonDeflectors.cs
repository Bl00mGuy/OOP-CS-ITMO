using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AntimatterFlashInHighDensityFogVaklasandVaklasWithPhotonDeflectors
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 100, 1)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double highDensityFogLength, int antimatterFlaresCount)
    {
        // Arrange
        var spaceship1 = new VaklasShip(false);
        var spaceship2 = new VaklasShip(true);

        var highDensityFogSegment = new HighDensityFog(antimatterFlaresCount, highDensityFogLength);

        var segments = new Collection<Environments> { highDensityFogSegment };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.CrewDied;
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