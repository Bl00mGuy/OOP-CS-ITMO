using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;

public interface IVideoCard : IComponent
{
    Dimensions DimensionsOfVideoCard { get; }
    int VideoMemory { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}