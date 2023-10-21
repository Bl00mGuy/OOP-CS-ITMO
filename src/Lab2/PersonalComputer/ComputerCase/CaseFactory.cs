using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public class CaseFactory : ICaseFactory
{
    public ICase CreateCase(string? name, Dimensions caseDimensions, Dimensions gpuDimensions, IList<MotherboardFormFactor> supportedMotherboards)
    {
        return new ComputerCase(name, caseDimensions, gpuDimensions, supportedMotherboards);
    }
}