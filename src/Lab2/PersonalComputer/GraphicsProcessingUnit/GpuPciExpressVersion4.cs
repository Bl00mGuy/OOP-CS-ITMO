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

    public string Name { get; private set; }
    public Dimensions DimensionsOfVideoCard { get; private set; }
    public int VideoMemory { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }

    public GpuPciExpressVersion4 Clone()
    {
        return new GpuPciExpressVersion4(
            (string)Name.Clone(),
            DimensionsOfVideoCard,
            VideoMemory,
            ChipFrequency,
            PowerConsumption);
    }

    public GpuPciExpressVersion4 SetGpuName(string name)
    {
        GpuPciExpressVersion4 gpuClone = Clone();

        gpuClone.Name = name;

        return gpuClone;
    }

    public GpuPciExpressVersion4 SetGpuDimensions(Dimensions gpuDimensions)
    {
        GpuPciExpressVersion4 gpuClone = Clone();

        gpuClone.DimensionsOfVideoCard = gpuDimensions;

        return gpuClone;
    }

    public GpuPciExpressVersion4 SetGpuVideoMemory(int gpuVideoMemory)
    {
        GpuPciExpressVersion4 gpuClone = Clone();

        gpuClone.VideoMemory = gpuVideoMemory;

        return gpuClone;
    }

    public GpuPciExpressVersion4 SetGpuChipFrequency(int gpuChipFrequency)
    {
        GpuPciExpressVersion4 gpuClone = Clone();

        gpuClone.ChipFrequency = gpuChipFrequency;

        return gpuClone;
    }

    public GpuPciExpressVersion4 SetGpuChipPowerConsumption(int gpuPowerConsumption)
    {
        GpuPciExpressVersion4 gpuClone = Clone();

        gpuClone.PowerConsumption = gpuPowerConsumption;

        return gpuClone;
    }
}