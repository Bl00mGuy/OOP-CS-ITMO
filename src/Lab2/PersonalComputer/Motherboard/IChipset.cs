using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public interface IChipset
{
    IList<int> PossibleDdrFrequency { get; }
}