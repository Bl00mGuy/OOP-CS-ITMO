using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

public interface IDdrStandard
{
    IList<Tuple<int, int>> SupportedJedecSettings { get; }
    IList<string> SupportedXmpProfiles { get; }
}