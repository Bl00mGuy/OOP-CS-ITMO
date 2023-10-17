using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public class Ddr3 : IDdrStandard
{
    public Ddr3(IList<Tuple<int, int>> jedecSettings, IList<string> xmpProfiles)
    {
        SupportedJedecSettings = jedecSettings;
        SupportedXmpProfiles = xmpProfiles;
    }

    public IList<Tuple<int, int>> SupportedJedecSettings { get; }

    public IList<string> SupportedXmpProfiles { get; }
}