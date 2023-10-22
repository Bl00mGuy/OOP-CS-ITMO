using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

public interface ISsd : IComponent
{
    DriveConnectionType ConnectionType { get; }
    int Capacity { get; }
    int MaxSpeed { get; }
    int PowerConsumption { get; }
}