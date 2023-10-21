using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public class ComputerCase : ICase
{
    public ComputerCase(string? name, Dimensions caseDimensions, Dimensions gpuDimensions, IList<MotherboardFormFactor> supportedMotherboards)
    {
        Name = name;
        DimensionsOfCase = caseDimensions;
        DimensionsOfGpu = gpuDimensions;
        SupportedMotherboards = supportedMotherboards;
    }

    public string? Name { get; private set; }
    public Dimensions DimensionsOfCase { get; private set; }
    public Dimensions DimensionsOfGpu { get; private set; }
    public IList<MotherboardFormFactor> SupportedMotherboards { get; private set; }

    public ComputerCase Clone()
    {
        return new ComputerCase(
            Name,
            DimensionsOfCase,
            DimensionsOfGpu,
            SupportedMotherboards);
    }

    public ComputerCase SetCaseName(string name)
    {
        ComputerCase caseClone = Clone();

        caseClone.Name = name;

        return caseClone;
    }

    public ComputerCase SetCaseDimensions(Dimensions caseDimensions)
    {
        ComputerCase caseClone = Clone();

        caseClone.DimensionsOfCase = caseDimensions;

        return caseClone;
    }

    public ComputerCase SetCaseGpuDimensions(Dimensions gpuDimensions)
    {
        ComputerCase caseClone = Clone();

        caseClone.DimensionsOfGpu = gpuDimensions;

        return caseClone;
    }

    public ComputerCase SetCaseSupportedMotherboards(IList<MotherboardFormFactor> supportedMotherboards)
    {
        ComputerCase caseClone = Clone();

        caseClone.SupportedMotherboards = supportedMotherboards;

        return caseClone;
    }
}