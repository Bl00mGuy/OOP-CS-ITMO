using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRam
{
    int MemorySize { get; }
    IList<IJedecProfile> SupportedJedecSettings { get; }
    IList<IXmpProfile> SupportedXmpProfiles { get; }
    RamFormFactor FormFactor { get; }
    int PowerConsumption { get; }
}