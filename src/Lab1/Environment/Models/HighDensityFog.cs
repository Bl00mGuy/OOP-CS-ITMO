using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class HighDensityFog : Environments
{
    public HighDensityFog(int antimatterFlaresCount, double lengthOfEnvironment)
    {
        AddObstacle(new AntimatterFlares(), antimatterFlaresCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}