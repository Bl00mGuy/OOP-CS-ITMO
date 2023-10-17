namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class PciExpressVersion4 : IVideoCard
{
    public PciExpressVersion4(Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        DimensionsOfVideoCard = dimensions;
        VideoMemory = videoMemory;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimensions DimensionsOfVideoCard { get; }
    public int VideoMemory { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
}