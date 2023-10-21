using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceWhalesInNitrineParticleFogVaklasAndAugurAndMeridian
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 1;
        const double fuelGravitonMatterPrice = 1;
        const double nitrineParticleFogLength = 100;
        const int countOfSpaceWhales = 2;
        const bool noPhotonDeflector = false;
        yield return new object[] { countOfSpaceWhales, noPhotonDeflector, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, nitrineParticleFogLength };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(int countOfSpaceWhales, bool noPhotonDeflector, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new VaklasShip(noPhotonDeflector);
        var spaceship2 = new AvgurShip(noPhotonDeflector);
        var spaceship3 = new MeredianShip(noPhotonDeflector);

        var obstacles = new Collection<Obstacle> { new SpaceWhales(countOfSpaceWhales) };

        var nitrineParticleFog = new NitrineParticleFog(obstacles, nitrineParticleFogLength);

        var segments = new Collection<Environments> { nitrineParticleFog };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.ShipDestroyed;
        const VoyageOutcomeType expectedOutput2 = VoyageOutcomeType.NoError;
        const VoyageOutcomeType expectedOutput3 = VoyageOutcomeType.NoError;

        // Act
        Route result1 = SendSpaceship(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result2 = SendSpaceship(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        Route result3 = SendSpaceship(spaceship3, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);

        // Assert
        Assert.Equal(expectedOutput1, result1.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, result2.ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput3, result3.ResultOfTheSpaceshipVoyage);
    }

    private static Route SendSpaceship(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }
}