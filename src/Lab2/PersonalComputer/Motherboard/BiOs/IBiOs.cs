using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public interface IBiOs
{
    int BiosVersion { get; }
    IList<ICpuFactory> SupportedCpus { get; }
}