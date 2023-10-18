using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public interface ICase
{
    Dimensions DimensionsOfCase { get; }
    Dimensions DimensionsOfGpu { get; }
    IList<MotherboardFormFactor> SupportedMotherboards { get; }
}