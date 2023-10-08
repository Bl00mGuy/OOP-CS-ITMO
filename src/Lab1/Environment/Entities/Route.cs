using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Route : Environments
{
    public Route(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        ResultOfTheSpaceshipVoyage = SendSpaceshipVoyage(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        InitialFuelActivePlasma = initialFuelActivePlasma;
        FuelActivePlasmaPrice = fuelActivePlasmaPrice;
        InitialFuelGravitonMatter = initialFuelGravitonMatter;
        FuelGravitonMatterPrice = fuelGravitonMatterPrice;
    }

    public double InitialFuelActivePlasma { get; private set; }
    public double FuelActivePlasmaPrice { get; private set; }
    public double InitialFuelGravitonMatter { get; private set; }
    public double FuelGravitonMatterPrice { get; private set; }
    public double TotalRouteLength { get; private set; }
    public double TotalRoutePrice { get; private set; }
    public VoyageErrorType ResultOfTheSpaceshipVoyage { get; private set; }

    public static VoyageErrorType SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
    {
        if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine != null)
        {
            return VoyageErrorType.EmptyTank;
        }

        if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
        {
            return VoyageErrorType.FuelNotFree;
        }

        if (segments.Count == 0)
        {
            return VoyageErrorType.NoSegments;
        }

        // Calculation of total route length and fuel calculation
        double remainingFuelActivePlasma = initialFuelActivePlasma;
        double remainingFuelGravitonMatter = initialFuelGravitonMatter;
        double totalLength = 0;
        if (spaceship.Engine != null)
        {
            if (spaceship.JumpEngine == null)
            {
                remainingFuelActivePlasma -= spaceship.Engine.StartEngine();
                foreach (Environments segment in segments)
                {
                    VoyageErrorType shipEnter = ShipEnterSphere(spaceship, segment);
                    if (!Equals(shipEnter, VoyageErrorType.NoError))
                    {
                        return shipEnter;
                    }

                    totalLength += segment.LengthOfEnvironment;
                    remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                }
            }
            else
            {
                remainingFuelActivePlasma -= spaceship.Engine.StartEngine();
                remainingFuelGravitonMatter -= spaceship.JumpEngine.StartEngine();
                foreach (Environments segment in segments)
                {
                    VoyageErrorType shipEnter = ShipEnterSphere(spaceship, segment);
                    if (!Equals(shipEnter, VoyageErrorType.NoError))
                    {
                        return shipEnter;
                    }

                    totalLength += segment.LengthOfEnvironment;
                    remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                }
            }
        }

        // Creating a route instance
        var route = new Route(spaceship, remainingFuelActivePlasma, remainingFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
        route.TotalRouteLength = totalLength;

        if (spaceship.JumpEngine != null)
        {
            route.TotalRoutePrice = (remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionClassCategory) + (remainingFuelGravitonMatter * fuelGravitonMatterPrice * spaceship.DimensionClassCategory);
        }
        else
        {
            route.TotalRoutePrice = remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionClassCategory;
        }

        if (remainingFuelActivePlasma < 0 || (spaceship.JumpEngine != null && remainingFuelGravitonMatter < 0))
        {
            return VoyageErrorType.NotEnoughFuel;
        }

        return VoyageErrorType.NoError;
    }
}