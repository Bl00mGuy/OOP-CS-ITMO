using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public interface ICaseFactory
{
    ICase CreateCase(string? name, Dimensions caseDimensions, Dimensions gpuDimensions, IList<MotherboardFormFactor> supportedMotherboards);
}