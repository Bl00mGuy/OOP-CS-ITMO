namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class PciExpressVersion4Factory : IVideoCardFactory
{
    public IVideoCard CreateVideoCard(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        return new PciExpressVersion4(dimensions, videoMemory, chipFrequency, powerConsumption);
    }
}