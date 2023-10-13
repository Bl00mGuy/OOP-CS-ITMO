using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Route : RouteResult
    {
        public Route(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
        {
            RouteResult result = SendSpaceshipVoyage(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
            TotalRoutePrice = result.Price;
            ResultOfTheSpaceshipVoyage = result.ResultType;
        }

        public double TotalRoutePrice { get; private set; }
        public VoyageOutcomeType ResultOfTheSpaceshipVoyage { get; private set; }

        private static RouteResult SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
        {
            var result = new RouteResult();

            if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine is not null)
            {
                result.ResultType = VoyageOutcomeType.EmptyTank;
                return result;
            }

            if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
            {
                result.ResultType = VoyageOutcomeType.FuelNotFree;
                return result;
            }

            if (segments.Count is 0)
            {
                result.ResultType = VoyageOutcomeType.NoSegments;
                return result;
            }

            double remainingFuelActivePlasma = initialFuelActivePlasma;
            double remainingFuelGravitonMatter = initialFuelGravitonMatter;
            double totalLength = 0;
            if (spaceship.Engine is not null)
            {
                if (spaceship.JumpEngine is null)
                {
                    remainingFuelActivePlasma -= spaceship.Engine.StartEngine();
                    foreach (Environments segment in segments)
                    {
                        VoyageOutcomeType shipEnter = segment.ShipEnterSphere(spaceship);
                        if (!Equals(shipEnter, VoyageOutcomeType.NoError))
                        {
                            result.ResultType = shipEnter;
                            return result;
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
                        VoyageOutcomeType shipEnter = segment.ShipEnterSphere(spaceship);
                        if (!Equals(shipEnter, VoyageOutcomeType.NoError))
                        {
                            result.ResultType = shipEnter;
                            return result;
                        }

                        totalLength += segment.LengthOfEnvironment;
                        remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                    }
                }
            }

            result.Price = totalLength;

            if (spaceship.JumpEngine is not null)
            {
                if (spaceship.DimensionCategory is not null)
                    result.Price = (remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionCategory.Dimensions) + (remainingFuelGravitonMatter * fuelGravitonMatterPrice * spaceship.DimensionCategory.Dimensions);
            }
            else
            {
                if (spaceship.DimensionCategory is not null)
                    result.Price = remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionCategory.Dimensions;
            }

            if (remainingFuelActivePlasma < 0 || (spaceship.JumpEngine is not null && remainingFuelGravitonMatter < 0))
            {
                result.ResultType = VoyageOutcomeType.NotEnoughFuel;
            }

            return result;
        }
    }