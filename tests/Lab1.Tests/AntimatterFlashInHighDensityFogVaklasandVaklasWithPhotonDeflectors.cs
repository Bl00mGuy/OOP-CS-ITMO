using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AntimatterFlashInHighDensityFogVaklasandVaklasWithPhotonDeflectors
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 1;
        const double fuelGravitonMatterPrice = 1;
        const double highDensityFogLength = 100;
        const int countOfAntimatterFlares = 1;
        const bool hasPhotonDeflector = true;
        yield return new object[] { !hasPhotonDeflector, hasPhotonDeflector, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, highDensityFogLength, countOfAntimatterFlares };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(bool noPhotonDeflector, bool hasPhotonDeflector, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double highDensityFogLength, int countOfAntimatterFlares)
    {
        // Arrange
        var spaceshipFirst = new VaklasShip(noPhotonDeflector);
        var spaceshipSecond = new VaklasShip(hasPhotonDeflector);

        var obstacles = new List<Obstacle> { new AntimatterFlares(countOfAntimatterFlares) };

        var highDensityFogSegment = new HighDensityFog(obstacles, highDensityFogLength);

        var segments = new Collection<Environments> { highDensityFogSegment };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.CrewDied;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

        // Act
        Route result1 = SendSpaceship1(spaceshipFirst, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result2 = SendSpaceship2(spaceshipSecond, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);

        // Assert
        Assert.Equal(expectedOutput1, result1.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, result2.ResultOfTheSpaceshipVoyage);
    }

    private static Route SendSpaceship1(VaklasShip spaceshipFirst, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        var route1 = new Route(spaceshipFirst, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        return route1;
    }

    private static Route SendSpaceship2(VaklasShip spaceshipSecond, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        var route2 = new Route(spaceshipSecond, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        return route2;
    }
}