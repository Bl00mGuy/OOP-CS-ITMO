using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public class CaseFactory : ICaseFactory
{
    public ICase CreateCase(Dimensions caseDimensions, Dimensions gpuDimensions, IList<MotherboardFormFactor> supportedMotherboards)
    {
        return new ComputerCase(caseDimensions, gpuDimensions, supportedMotherboards);
    }
}