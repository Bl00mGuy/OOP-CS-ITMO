using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr5Factory : IRamFactory
{
    public IRam CreateRam(int memorySize, IList<IJedecProfile> supportedJedecSettings, IList<IXmpProfile> supportedXmpProfiles, RamFormFactor formFactor, int powerConsumption)
    {
        return new Ddr5(memorySize, supportedJedecSettings, supportedXmpProfiles, formFactor, powerConsumption);
    }
}