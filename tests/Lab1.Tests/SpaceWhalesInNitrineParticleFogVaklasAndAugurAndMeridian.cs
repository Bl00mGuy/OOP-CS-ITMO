using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceWhalesInNitrineParticleFogVaklasAndAugurAndMeridian
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 100)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new VaklasShip(false);
        var spaceship2 = new AvgurShip(false);
        var spaceship3 = new MeredianShip(false);

        var nitrineParticleFog = new NitrineParticleFog(2, nitrineParticleFogLength);

        var segments = new Collection<Environments> { nitrineParticleFog };

        // const string expectedOutput1 = "The spaceship has been destroyed";
        // const string expectedOutput2 = "The spacecraft has successfully complete voyage";
        // const string expectedOutput3 = "The spacecraft has successfully complete voyage";
        const VoyageErrorType expectedOutput1 = VoyageErrorType.ShipDestroyed;
        const VoyageErrorType expectedOutput2 = VoyageErrorType.NoError;
        const VoyageErrorType expectedOutput3 = VoyageErrorType.NoError;

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1().ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, SendSpaceship2().ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput3, SendSpaceship3().ResultOfTheSpaceshipVoyage);
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

        Route SendSpaceship3()
        {
            var route3 = new Route(spaceship3, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
            return route3;
        }
    }
}