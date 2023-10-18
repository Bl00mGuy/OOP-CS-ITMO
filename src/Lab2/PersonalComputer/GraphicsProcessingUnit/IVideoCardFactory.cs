using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public interface IVideoCardFactory
{
    IVideoCard CreateVideoCard(string gpuName, Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption);
}