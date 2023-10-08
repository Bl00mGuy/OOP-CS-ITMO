using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class HighDensityFog : Environments
{
    public HighDensityFog(int antimatterFlaresCount, double lengthOfEnvironment)
    {
        RequiredEngines = typeof(IEngine);
        RequiredJumpEngines = typeof(IJumpEngine);
        AddObstacle("AntimatterFlare", antimatterFlaresCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}