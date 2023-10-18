using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface IHdd : IComponent
{
    int Capacity { get; }
    int SpindleSpeed { get; }
    int PowerConsumption { get; }
}