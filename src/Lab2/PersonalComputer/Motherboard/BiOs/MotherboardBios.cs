using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class MotherboardBios : IBiOs
{
    public MotherboardBios(int version, IList<ICpuFactory> supportedCpus)
    {
        BiosVersion = version;
        SupportedCpus = supportedCpus;
    }

    public int BiosVersion { get; }
    public IList<ICpuFactory> SupportedCpus { get; }
}