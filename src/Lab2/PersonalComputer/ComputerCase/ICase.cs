using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;

public interface ICase : IComponent
{
    Dimensions DimensionsOfCase { get; }
    Dimensions DimensionsOfGpu { get; }
    IList<MotherboardFormFactor> SupportedMotherboards { get; }
}