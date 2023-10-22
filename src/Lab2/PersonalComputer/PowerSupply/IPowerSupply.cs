using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;

public interface IPowerSupply : IComponent
{
    int PeakLoad { get; }
}