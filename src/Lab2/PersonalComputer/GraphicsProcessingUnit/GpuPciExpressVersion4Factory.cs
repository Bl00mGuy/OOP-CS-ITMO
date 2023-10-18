namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class GpuPciExpressVersion4Factory : IVideoCardFactory
{
    public IVideoCard CreateVideoCard(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        return new GpuPciExpressVersion4(dimensions, videoMemory, chipFrequency, powerConsumption);
    }
}