namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class RouteResult
{
    public double Price { get; private set; }
    public VoyageOutcomeType ResultType { get; private set; }

    public void SetRoutePrice(double price)
    {
        Price = price;
    }

    public void SetRouteResult(VoyageOutcomeType result)
    {
        ResultType = result;
    }
}