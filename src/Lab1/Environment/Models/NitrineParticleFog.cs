using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public class NitrineParticleFog : Environments
{
    public NitrineParticleFog(int spaceWhalesCount, double lengthOfEnvironment)
    {
        RequiredEngines = typeof(ImpulseEngineClassE);
        AddObstacle(new SpaceWhales(), spaceWhalesCount);
        LengthOfEnvironment = lengthOfEnvironment;
    }
}