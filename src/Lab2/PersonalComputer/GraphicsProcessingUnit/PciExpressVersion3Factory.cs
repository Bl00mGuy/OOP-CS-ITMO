namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class PciExpressVersion3Factory : IVideoCardFactory
{
    public IVideoCard CreateVideoCard(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        return new PciExpressVersion3(dimensions, videoMemory, chipFrequency, powerConsumption);
    }
}