using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class HeavyDimensions : IDimensionCategory
{
    private const int HeavyWeight = 3;

    public int Dimensions => HeavyWeight;
}