namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Entities.Environment
{
    public NitrineParticleFog(int spaceWhalesCount, int lengthOfEnvironment)
    {
        AddRequiredEngineName("Impulse Engine Class E");
        AddObstacle("SpaceWhale", spaceWhalesCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}