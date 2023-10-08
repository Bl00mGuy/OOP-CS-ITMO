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

        public double TotalRouteLength { get; private set; }
        public double TotalRoutePrice { get; private set; }
        public VoyageErrorType ResultOfTheSpaceshipVoyage { get; private set; }

        private static RouteResult SendSpaceshipVoyage(Spaceship spaceship, double initialFuelActivePlasma, double initialFuelGravitonMatter, double fuelActivePlasmaPrice, double fuelGravitonMatterPrice, Collection<Environments> segments)
        {
            var result = new RouteResult();

            if (initialFuelActivePlasma <= 0 && spaceship.JumpEngine != null)
            {
                result.ErrorType = VoyageErrorType.EmptyTank;
                return result;
            }

            if (fuelActivePlasmaPrice <= 0 || fuelGravitonMatterPrice <= 0)
            {
                result.ErrorType = VoyageErrorType.FuelNotFree;
                return result;
            }

            if (segments.Count == 0)
            {
                result.ErrorType = VoyageErrorType.NoSegments;
                return result;
            }

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
                            result.ErrorType = shipEnter;
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
                        VoyageErrorType shipEnter = ShipEnterSphere(spaceship, segment);
                        if (!Equals(shipEnter, VoyageErrorType.NoError))
                        {
                            result.ErrorType = shipEnter;
                            return result;
                        }

                        totalLength += segment.LengthOfEnvironment;
                        remainingFuelActivePlasma -= spaceship.Engine.CalculateFuelConsumption(segment.LengthOfEnvironment);
                    }
                }
            }

            result.Price = totalLength;

            if (spaceship.JumpEngine != null)
            {
                result.Price = (remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionClassCategory) + (remainingFuelGravitonMatter * fuelGravitonMatterPrice * spaceship.DimensionClassCategory);
            }
            else
            {
                result.Price = remainingFuelActivePlasma * fuelActivePlasmaPrice * spaceship.DimensionClassCategory;
            }

            if (remainingFuelActivePlasma < 0 || (spaceship.JumpEngine != null && remainingFuelGravitonMatter < 0))
            {
                result.ErrorType = VoyageErrorType.NotEnoughFuel;
            }

            return result;
        }
    }