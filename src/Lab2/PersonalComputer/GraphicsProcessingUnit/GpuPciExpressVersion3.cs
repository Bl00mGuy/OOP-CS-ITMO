using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public class GpuPciExpressVersion3 : IVideoCard
{
    public GpuPciExpressVersion3(string gpuName, Dimensions dimensions, int videoMemory, int chipFrequency, int powerConsumption)
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

    public GpuPciExpressVersion3 Clone()
    {
        return new GpuPciExpressVersion3(
            (string)Name.Clone(),
            DimensionsOfVideoCard,
            VideoMemory,
            ChipFrequency,
            PowerConsumption);
    }

    public GpuPciExpressVersion3 SetGpuName(string name)
    {
        GpuPciExpressVersion3 gpuClone = Clone();

        gpuClone.Name = name;

        return gpuClone;
    }

    public GpuPciExpressVersion3 SetGpuDimensions(Dimensions gpuDimensions)
    {
        GpuPciExpressVersion3 gpuClone = Clone();

        gpuClone.DimensionsOfVideoCard = gpuDimensions;

        return gpuClone;
    }

    public GpuPciExpressVersion3 SetGpuVideoMemory(int gpuVideoMemory)
    {
        GpuPciExpressVersion3 gpuClone = Clone();

        gpuClone.VideoMemory = gpuVideoMemory;

        return gpuClone;
    }

    public GpuPciExpressVersion3 SetGpuChipFrequency(int gpuChipFrequency)
    {
        GpuPciExpressVersion3 gpuClone = Clone();

        gpuClone.ChipFrequency = gpuChipFrequency;

        return gpuClone;
    }

    public GpuPciExpressVersion3 SetGpuChipPowerConsumption(int gpuPowerConsumption)
    {
        GpuPciExpressVersion3 gpuClone = Clone();

        gpuClone.PowerConsumption = gpuPowerConsumption;

        return gpuClone;
    }
}