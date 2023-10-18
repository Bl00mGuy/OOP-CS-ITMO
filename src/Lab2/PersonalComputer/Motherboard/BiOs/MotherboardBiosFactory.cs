using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class MotherboardBiosFactory : IBiOsFactory
{
    public IBiOs CreateBiOs(int version, IList<ICpuFactory> supportedCpus)
    {
        return new MotherboardBios(version, supportedCpus);
    }
}