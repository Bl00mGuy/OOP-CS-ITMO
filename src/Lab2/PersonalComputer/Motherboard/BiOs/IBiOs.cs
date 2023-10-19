using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public interface IBiOs
{
    int BiosVersion { get; }
    IList<string> SupportedCpus { get; }
}