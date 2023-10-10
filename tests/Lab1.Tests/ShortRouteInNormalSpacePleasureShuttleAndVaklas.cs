using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShortRouteInNormalSpacePleasureShuttleAndVaklas
{
    [Theory]
    [InlineData(10000, 10000, 12, 14, 100, 0, 0)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double normalSpaceLength, int smallAsteroidsCount, int meteoritesCount)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new VaklasShip(false);

        var normalSpace = new NormalSpace(smallAsteroidsCount, meteoritesCount, normalSpaceLength);

        var segments = new Collection<Environments> { normalSpace };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.NoError;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1().ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, SendSpaceship2().ResultOfTheSpaceshipVoyage);
        Assert.True(SendSpaceship1().TotalRoutePrice < SendSpaceship2().TotalRoutePrice);

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