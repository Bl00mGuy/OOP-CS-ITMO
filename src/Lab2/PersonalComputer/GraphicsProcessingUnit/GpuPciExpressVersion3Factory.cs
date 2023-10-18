namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class GpuPciExpressVersion3Factory : IVideoCardFactory
{
    public IVideoCard CreateVideoCard(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        return new GpuPciExpressVersion3(dimensions, videoMemory, chipFrequency, powerConsumption);
    }
}