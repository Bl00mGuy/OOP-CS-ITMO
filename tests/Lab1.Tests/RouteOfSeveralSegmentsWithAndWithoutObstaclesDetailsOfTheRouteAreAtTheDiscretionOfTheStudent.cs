using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteOfSeveralSegmentsWithAndWithoutObstaclesDetailsOfTheRouteAreAtTheDiscretionOfTheStudent
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 1;
        const double fuelGravitonMatterPrice = 1;
        const double normalSpaceLength = 300;
        const double highDensityFogLength = 100;
        const double nitrineParticleFogLength = 200;
        const int countOfSmallAsteroid = 3;
        const int countOfMeteorite = 4;
        const int countOfAntimatterFlares = 1;
        const int countOfSpaceWhales = 1;
        const bool hasPhotonDeflector = true;
        yield return new object[] { countOfSmallAsteroid, countOfMeteorite, countOfAntimatterFlares, countOfSpaceWhales, hasPhotonDeflector, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, normalSpaceLength, highDensityFogLength, nitrineParticleFogLength };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(int countOfSmallAsteroid, int countOfMeteorite, int countOfAntimatterFlares, int countOfSpaceWhales, bool hasPhotonDeflector, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double normalSpaceLength, double highDensityFogLength, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip(hasPhotonDeflector);

        var obstacles = new Collection<Obstacle> { new SmallAsteroid(countOfSmallAsteroid),  new Meteorite(countOfMeteorite), new AntimatterFlares(countOfAntimatterFlares), new SpaceWhales(countOfSpaceWhales) };

        var normalSpace = new NormalSpace(obstacles, normalSpaceLength);
        var highDensityFogSegment = new HighDensityFog(obstacles, highDensityFogLength);
        var nitrineParticleFog = new NitrineParticleFog(obstacles, nitrineParticleFogLength);

        var segments = new Collection<Environments> { normalSpace, highDensityFogSegment, nitrineParticleFog };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.ShipDestroyed;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

        // Act
        Route result1 = SendSpaceship1(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result2 = SendSpaceship2(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);

        // Assert
        Assert.Equal(expectedOutput1, result1.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, result2.ResultOfTheSpaceshipVoyage);
    }

    private static Route SendSpaceship1(PleasureShuttleShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }

    private static Route SendSpaceship2(AvgurShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }
}