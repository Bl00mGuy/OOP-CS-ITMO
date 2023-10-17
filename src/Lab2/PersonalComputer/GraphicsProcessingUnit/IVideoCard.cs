namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public interface IVideoCard
{
    Dimensions DimensionsOfVideoCard { get; }
    int VideoMemory { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}