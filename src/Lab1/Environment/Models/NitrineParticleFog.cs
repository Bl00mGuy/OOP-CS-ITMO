using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Environments
{
    public NitrineParticleFog(int spaceWhalesCount, double lengthOfEnvironment)
    {
        AddObstacle(new SpaceWhales(), spaceWhalesCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}