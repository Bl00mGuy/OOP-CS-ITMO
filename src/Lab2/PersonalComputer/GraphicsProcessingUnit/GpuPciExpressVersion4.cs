using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class GpuPciExpressVersion4 : IVideoCard
{
    public GpuPciExpressVersion4(string gpuName, Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
    {
        Name = gpuName;
        DimensionsOfVideoCard = dimensions;
        VideoMemory = videoMemory;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public Dimensions DimensionsOfVideoCard { get; }
    public int VideoMemory { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
}