using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class BiOsVersion1Factory : IBiOsFactory
{
    public IBiOs CreateBiOs(string type, IList<ICpuFactory> supportedCpus)
    {
        return new BiosVersion1(type, supportedCpus);
    }
}