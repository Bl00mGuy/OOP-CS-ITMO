using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MediumLengthRouteInHighDensityFogAugurAndStella
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 1;
        const double fuelGravitonMatterPrice = 1;
        const double highDensityFogLength = 200;
        const int countOfAntimatterFlares = 0;
        const bool noPhotonDeflector = false;
        yield return new object[] { noPhotonDeflector, countOfAntimatterFlares, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, highDensityFogLength };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(bool noPhotonDeflector, int countOfAntimatterFlares, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new AvgurShip(noPhotonDeflector);
        var spaceship2 = new StellaShip(noPhotonDeflector);

        var obstacles = new List<Obstacle> { new AntimatterFlares(countOfAntimatterFlares) };

        var highDensityFogSegment = new HighDensityFog(obstacles, highDensityFogLength);

        var segments = new Collection<Environments> { highDensityFogSegment };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.MaxJumpLengthExceeded;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;

        // Act
        Route result1 = SendSpaceship1(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result2 = SendSpaceship2(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);

        // Assert
        Assert.Equal(expectedOutput1, result1.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, result2.ResultOfTheSpaceshipVoyage);
    }

    private static Route SendSpaceship1(AvgurShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }

    private static Route SendSpaceship2(StellaShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }
}