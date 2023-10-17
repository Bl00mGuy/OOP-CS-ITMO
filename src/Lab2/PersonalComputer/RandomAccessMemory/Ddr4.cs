using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr4 : IRam
{
    public Ddr4(int memorySize, IList<IJedecProfile> supportedJedecSettings, IList<IXmpProfile> supportedXmpProfiles, RamFormFactor formFactor, int powerConsumption)
    {
        MemorySize = memorySize;
        SupportedJedecSettings = supportedJedecSettings;
        SupportedXmpProfiles = supportedXmpProfiles;
        FormFactor = formFactor;
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get; }
    public IList<IJedecProfile> SupportedJedecSettings { get; }
    public IList<IXmpProfile> SupportedXmpProfiles { get; }
    public RamFormFactor FormFactor { get; }
    public int PowerConsumption { get; }
}