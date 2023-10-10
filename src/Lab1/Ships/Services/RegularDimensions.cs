using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class RegularDimensions : IDimensionCategory
{
    private const int RegularWeight = 2;

    public int Dimensions => RegularWeight;
}