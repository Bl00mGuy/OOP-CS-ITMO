namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class HighDensityFog : Entities.Environment
{
    public HighDensityFog(int antimatterFlaresCount, int lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class C");
        AddRequiredEngineName("Impulse Engine Class E");
        AddRequiredEngineName("Jump Engine Alpha");
        AddRequiredEngineName("Jump Engine Omega");
        AddRequiredEngineName("Jump Engine Gamma");
        AddObstacle("AntimatterFlare", antimatterFlaresCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}