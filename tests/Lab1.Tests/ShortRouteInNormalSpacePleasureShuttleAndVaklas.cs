using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShortRouteInNormalSpacePleasureShuttleAndVaklas
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 12;
        const double fuelGravitonMatterPrice = 14;
        const double normalSpaceLength = 100;
        const int countOfSmallAsteroid = 0;
        const int countOfMeteorite = 0;
        const bool hasPhotonDeflector = false;
        yield return new object[] { countOfSmallAsteroid, countOfMeteorite, hasPhotonDeflector, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, normalSpaceLength };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(int countOfSmallAsteroid, int countOfMeteorite, bool hasPhotonDeflector, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double normalSpaceLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new VaklasShip(hasPhotonDeflector);

        var obstacles = new Collection<Obstacle> { new SmallAsteroid(countOfSmallAsteroid), new Meteorite(countOfMeteorite) };

        var normalSpace = new NormalSpace(obstacles, normalSpaceLength);

        var segments = new Collection<Environments> { normalSpace };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.NoError;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

        // Act
        Route result1 = SendSpaceship1(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result2 = SendSpaceship2(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);

        // Assert
        Assert.Equal(expectedOutput1, result1.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, result2.ResultOfTheSpaceshipVoyage);
        Assert.True(result1.TotalRoutePrice < result2.TotalRoutePrice);
    }

    private static Route SendSpaceship1(PleasureShuttleShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }

    private static Route SendSpaceship2(VaklasShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }
}