using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRam
{
    int MemorySize { get; }
    IList<Tuple<int, int>> SupportedJEDECSettings { get; }
    IList<string> SupportedXMPProfiles { get; }
    RamFormFactor FormFactor { get; }
    int PowerConsumption { get; }
}