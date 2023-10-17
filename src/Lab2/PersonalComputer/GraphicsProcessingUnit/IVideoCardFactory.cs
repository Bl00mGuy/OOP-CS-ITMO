namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public interface IVideoCardFactory
{
    IVideoCard CreateVideoCard(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption);
}