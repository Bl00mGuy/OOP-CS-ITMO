using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Route : Environment
{
    private Collection<Environment> _routeSegments = new Collection<Environment>(); // Список отрезков пути маршрута
    public Route(double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice)
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

    public static Route SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environment> segments)
    {
        if (spaceship == null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Unable to identify the spaceship!");
        }

        if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine != null)
        {
            throw new ArgumentOutOfRangeException(nameof(initialFuelActivePlasma), "A spaceship cannot fly with an empty tank!");
        }

        if (initialFuelGravitonMatter <= 0 && spaceship.JumpEngine != null)
        {
            throw new ArgumentOutOfRangeException(nameof(initialFuelGravitonMatter), "A spaceship cannot fly with an empty tank!");
        }

        if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
        {
            throw new ArgumentException("Wake up! Fuel cannot be free!");
        }

        if (segments == null || segments.Count == 0)
        {
            throw new ArgumentException("Route must contain at least one segment!", nameof(segments));
        }

        // Рассчитываем общую длину маршрута и Расчет оставшегося топлива после прохождения маршрута
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
                    ShipEnterSphere(spaceship, segment);
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
                    // Пофиксить длину пути от типа сферы и потребление топлива для прыжковых
                    totalLength += segment.LengthOfEnvironment;
                    remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                }
            }
        }

        // Создание экземпляра маршрута
        var route = new Route(remainingFuelActivePlasma, remainingFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice);
        route._routeSegments = segments; // Доработать
        route.TotalRouteLength = totalLength;

        if (spaceship.JumpEngine != null)
        {
            route.TotalRoutePrice = (remainingFuelActivePlasma * fuelActivePlasmaPrice) + (remainingFuelGravitonMatter * fuelGravitonMatterPrice);
        }
        else
        {
            route.TotalRoutePrice = remainingFuelActivePlasma * fuelActivePlasmaPrice;
        }

        // Исход поездки
        if (remainingFuelActivePlasma < 0 || (spaceship.JumpEngine != null && remainingFuelGravitonMatter < 0))
        {
            throw new InvalidOperationException($"There is not enough fuel for {spaceship.Name} ship to complete the route! The spaceship was lost!");
        }

        return route;
    }

    public void CreateSegment(EnvironmentType environmentType, int firstParameter, int secondParameter, int environmentLength)
    {
        Environment segment = environmentType switch
        {
            EnvironmentType.NormalSpace => new NormalSpace(firstParameter, secondParameter, environmentLength),
            EnvironmentType.HighDensityFog => new HighDensityFog(firstParameter, environmentLength),
            EnvironmentType.NitrineParticleFog => new NitrineParticleFog(firstParameter, environmentLength),
            _ => throw new ArgumentException("Invalid environment type!", nameof(environmentType)),
        };
        _routeSegments.Add(segment);
    }
}