using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    [Theory]
    [InlineData(10000, 10000, 12, 14, 100)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, int highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new VaklasShip(false);

        var normalSpace = new NormalSpace(0, 0, highDensityFogLength);

        var segments = new Collection<Environment.Entities.Environment> { normalSpace };

        // Act
        string SendSpaceship1()
        {
            return Route.SendSpaceshipVoyage(spaceship1, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        string SendSpaceship2()
        {
            return Route.SendSpaceshipVoyage(spaceship2, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        }

        // Assert
        if (spaceship1.Route != null && spaceship2.Route != null)
        {
            Assert.Equal("The spacecraft has successfully complete voyage", SendSpaceship1());
            Assert.Equal("The spacecraft has successfully complete voyage", SendSpaceship2());
            Assert.True(spaceship1.Route.TotalRoutePrice < spaceship2.Route.TotalRoutePrice);
        }
    }
}