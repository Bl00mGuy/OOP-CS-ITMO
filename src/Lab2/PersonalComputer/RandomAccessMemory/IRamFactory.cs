using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IRamFactory
{
    IRam CreateRam(int memorySize, IList<IJedecProfile> supportedJedecSettings, IList<IXmpProfile> supportedXmpProfiles, RamFormFactor formFactor, int powerConsumption);
}