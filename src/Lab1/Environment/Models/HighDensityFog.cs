namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class HighDensityFog : Entities.Environment
{
    public HighDensityFog(int antimatterFlaresCount, double lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class C");
        AddRequiredEngineName("Impulse Engine Class E");
        AddRequiredJumpEngineName("Jump Engine Alpha");
        AddRequiredJumpEngineName("Jump Engine Omega");
        AddRequiredJumpEngineName("Jump Engine Gamma");
        AddObstacle("AntimatterFlare", antimatterFlaresCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}