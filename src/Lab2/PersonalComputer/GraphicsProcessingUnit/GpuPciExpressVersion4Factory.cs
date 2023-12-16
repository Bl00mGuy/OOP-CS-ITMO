using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class GpuPciExpressVersion4Factory : IVideoCardFactory
{
    public IVideoCard CreateVideoCard(string gpuName, Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        return new GpuPciExpressVersion4(gpuName, dimensions, videoMemory, chipFrequency, powerConsumption);
    }
}