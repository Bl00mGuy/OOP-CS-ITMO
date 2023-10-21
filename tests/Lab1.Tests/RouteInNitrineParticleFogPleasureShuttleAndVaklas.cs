using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteInNitrineParticleFogPleasureShuttleAndVaklas
{
    public static IEnumerable<object[]> TestParameters()
    {
        const double initialFuelActivePlasma = 10000;
        const double initialFuelGravitonMatter = 10000;
        const double fuelActivePlasmaPrice = 1;
        const double fuelGravitonMatterPrice = 1;
        const double nitrineParticleFogLength = 200;
        const int countOfSpaceWhales = 0;
        const bool noPhotonDeflector = false;
        yield return new object[] { noPhotonDeflector, countOfSpaceWhales, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, nitrineParticleFogLength };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestRouteForSpaceships(bool noPhotonDeflector, int countOfSpaceWhales, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new VaklasShip(noPhotonDeflector);

        var obstacles = new Collection<Obstacle> { new SpaceWhales(countOfSpaceWhales) };

        var nitrineParticleFog = new NitrineParticleFog(obstacles, nitrineParticleFogLength);

        var segments = new Collection<Environments> { nitrineParticleFog };

        const VoyageOutcomeType expectedOutput1 = VoyageOutcomeType.MissingRequiredEngine;
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

    private static Route SendSpaceship2(VaklasShip spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        return new Route(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
    }
}