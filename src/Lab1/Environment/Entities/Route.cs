using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Route : Environment
{
    private Collection<Environment> _routeSegments = new();
    private Route(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice)
    {
        InitialFuelActivePlasma = initialFuelActivePlasma;
        FuelActivePlasmaPrice = fuelActivePlasmaPrice;
        InitialFuelGravitonMatter = initialFuelGravitonMatter;
        FuelGravitonMatterPrice = fuelGravitonMatterPrice;
        TotalRouteLength = 0;
        TotalRoutePrice = 0;
    }

    public double InitialFuelActivePlasma { get; private set; }
    public double FuelActivePlasmaPrice { get; private set; }
    public double InitialFuelGravitonMatter { get; private set; }
    public double FuelGravitonMatterPrice { get; private set; }
    public double TotalRouteLength { get; private set; }
    public double TotalRoutePrice { get; private set; }

    public static string SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environment> segments)
    {
        if (spaceship == null)
        {
            return "Unable to identify the spaceship!";
        }

        if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine != null)
        {
            return "A spaceship cannot fly with an empty tank!";
        }

        if (initialFuelGravitonMatter <= 0 && spaceship.JumpEngine != null)
        {
            return "A spaceship cannot fly with an empty tank!";
        }

        if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
        {
            return "Wake up! Fuel cannot be free!";
        }

        if (segments == null || segments.Count == 0)
        {
            return "Route must contain at least one segment!";
        }

        // Рассчёт общей длины маршрута и расчет топлива
        double remainingFuelActivePlasma = initialFuelActivePlasma;
        double remainingFuelGravitonMatter = initialFuelGravitonMatter;
        double totalLength = 0;
        if (spaceship.Engine != null)
        {
            if (spaceship.JumpEngine == null)
            {
                remainingFuelActivePlasma -= spaceship.Engine.StartEngine();
                foreach (Environment segment in segments)
                {
                    string shipEnter = ShipEnterSphere(spaceship, segment);
                    if (!Equals(shipEnter, "OK"))
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
                foreach (Environment segment in segments)
                {
                    string shipEnter = ShipEnterSphere(spaceship, segment);
                    if (!Equals(shipEnter, "OK"))
                    {
                        return shipEnter;
                    }

                    totalLength += segment.LengthOfEnvironment;
                    remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                }
            }
        }

        // Создание экземпляра маршрута
        var route = new Route(remainingFuelActivePlasma, remainingFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice);
        route._routeSegments = segments;
        route.TotalRouteLength = totalLength;

        if (spaceship.JumpEngine != null)
        {
            route.TotalRoutePrice = (remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.MassClass) + (remainingFuelGravitonMatter * fuelGravitonMatterPrice * spaceship.MassClass);
        }
        else
        {
            route.TotalRoutePrice = remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.MassClass;
        }

        // Исход поездки
        if (remainingFuelActivePlasma < 0 || (spaceship.JumpEngine != null && remainingFuelGravitonMatter < 0))
        {
            return "There is not enough fuel for spaceship to complete the route!";
        }

        spaceship.SetRoute(route);

        return "The spacecraft has successfully complete voyage";
    }
}