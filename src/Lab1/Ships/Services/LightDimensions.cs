using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

public class LightDimensions : IDimensionCategory
{
    private const int LightWeight = 1;

    public int Dimensions => LightWeight;
}