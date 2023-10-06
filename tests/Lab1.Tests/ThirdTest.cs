using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTest
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, (double)DistanceType.Small)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double nitrineParticleFogLength)
    {
        // Arrange
        var spaceship1 = new VaklasShip(false);
        var spaceship2 = new AvgurShip(false);
        var spaceship3 = new MeredianShip(false);

        var nitrineParticleFog = new NitrineParticleFog(1, nitrineParticleFogLength);

        var segments = new Collection<Environment.Entities.Environments> { nitrineParticleFog };

        const string expectedOutput1 = "The spaceship has been destroyed";
        const string expectedOutput2 = "The spacecraft has successfully complete voyage";
        const string expectedOutput3 = "The spacecraft has successfully complete voyage";

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1());
        Assert.Equal(expectedOutput2, SendSpaceship2());
        Assert.Equal(expectedOutput3, SendSpaceship3());
        return;

        // Act
        string SendSpaceship1()
        {
            return Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship2()
        {
            return Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship3()
        {
            return Route.SendSpaceshipVoyage(spaceship3, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }
    }
}