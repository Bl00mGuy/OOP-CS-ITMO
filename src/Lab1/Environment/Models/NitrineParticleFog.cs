namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Entities.Environments
{
    public NitrineParticleFog(int spaceWhalesCount, double lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class E");
        AddObstacle("SpaceWhale", spaceWhalesCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}