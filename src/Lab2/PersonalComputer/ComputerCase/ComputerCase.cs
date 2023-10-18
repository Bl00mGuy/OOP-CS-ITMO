using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public class ComputerCase : ICase
{
    public ComputerCase(Dimensions caseDimensions, Dimensions gpuDimensions, IList<MotherboardFormFactor> supportedMotherboards)
    {
        DimensionsOfCase = caseDimensions;
        DimensionsOfGpu = gpuDimensions;
        SupportedMotherboards = supportedMotherboards;
    }

    public Dimensions DimensionsOfCase { get; }
    public Dimensions DimensionsOfGpu { get; }
    public IList<MotherboardFormFactor> SupportedMotherboards { get; }
}