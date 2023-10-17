using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr4Factory : IRamFactory
{
    public IRam CreateRam(int memorySize, IList<IJedecProfile> supportedJedecSettings, IList<IXmpProfile> supportedXmpProfiles, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ddr4(memorySize, supportedJedecSettings, supportedXmpProfiles, formFactor, powerConsumption);
    }
}