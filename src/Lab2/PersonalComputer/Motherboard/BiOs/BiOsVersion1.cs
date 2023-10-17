using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class BiosVersion1 : IBiOs
{
    public BiosVersion1(string type, IList<ICpuFactory> supportedCpus)
    {
        Type = type;
        SupportedCpus = supportedCpus;
    }

    public string Type { get; }

    public IList<ICpuFactory> SupportedCpus { get; }
}