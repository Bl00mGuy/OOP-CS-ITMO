using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MediumLengthRouteInHighDensityFogPleasureShuttleAndAvgur
{
    [Theory]
    [InlineData(10000, 10000, 1, 1, 200)]
    public void TestRouteForSpaceships(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, double highDensityFogLength)
    {
        // Arrange
        var spaceship1 = new PleasureShuttleShip();
        var spaceship2 = new AvgurShip(false);

        var highDensityFogSegment = new HighDensityFog(0, highDensityFogLength);

        var segments = new Collection<Environments> { highDensityFogSegment };

        // const string expectedOutput1 = "Spaceship doesn't have a required jump engine!";
        // const string expectedOutput2 = "Spaceship doesn't have a required jump engine max jump length!";
        const VoyageErrorType expectedOutput1 = VoyageErrorType.MissingRequiredJumpEngine;
        const VoyageErrorType expectedOutput2 = VoyageErrorType.MaxJumpLengthExceeded;

        // Assert
        Assert.Equal(expectedOutput1, SendSpaceship1().ResultOfTheSpaceshipVoyage);
        Assert.Equal(expectedOutput2, SendSpaceship2().ResultOfTheSpaceshipVoyage);
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