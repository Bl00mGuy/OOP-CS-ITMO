using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Route : Environments
    {
        public Route(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
        {
            RouteResult result = SendSpaceshipVoyage(spaceship, initialFuelActivePlasma, initialFuelGravitonMatter, fuelActivePlasmaPrice, fuelGravitonMatterPrice, segments);
            TotalRoutePrice = result.Price;
            ResultOfTheSpaceshipVoyage = result.ErrorType;
        }

        public double TotalRoutePrice { get; private set; }
        public VoyageOutcomeType ResultOfTheSpaceshipVoyage { get; private set; }

        private static RouteResult SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
        {
            var result = new RouteResult();

            if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine is not null)
            {
                result.ErrorType = VoyageOutcomeType.EmptyTank;
                return result;
            }

            if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
            {
                result.ErrorType = VoyageOutcomeType.FuelNotFree;
                return result;
            }

            if (segments.Count is 0)
            {
                result.ErrorType = VoyageOutcomeType.NoSegments;
                return result;
            }

            double remainingFuelActivePlasma = initialFuelActivePlasma;
            double remainingFuelGravitonMatter = initialFuelGravitonMatter;
            double totalLength = 0;
            if (spaceship.Engine is not null)
            {
                if (spaceship.JumpEngine is null)
                {
                    remainingFuelActivePlasma -= 1; // spaceship.Engine.StartEngine();
                    foreach (Environments segment in segments)
                    {
                        VoyageOutcomeType shipEnter = ShipEnterSphere(spaceship, segment);
                        if (!Equals(shipEnter, VoyageOutcomeType.NoError))
                        {
                            result.ErrorType = shipEnter;
                            return result;
                        }

                        totalLength += segment.LengthOfEnvironment;
                        remainingFuelActivePlasma -= 1; // spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                    }
                }
                else
                {
                    remainingFuelActivePlasma -= 1; // spaceship.Engine.StartEngine();
                    remainingFuelGravitonMatter -= spaceship.JumpEngine.StartEngine();
                    foreach (Environments segment in segments)
                    {
                        VoyageOutcomeType shipEnter = ShipEnterSphere(spaceship, segment);
                        if (!Equals(shipEnter, VoyageOutcomeType.NoError))
                        {
                            result.ErrorType = shipEnter;
                            return result;
                        }

                        totalLength += segment.LengthOfEnvironment;
                        remainingFuelActivePlasma -= 1; // spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
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
                result.ErrorType = VoyageOutcomeType.NotEnoughFuel;
            }

            return result;
        }
    }