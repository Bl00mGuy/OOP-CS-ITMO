using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public class MotherboardBiosFactory : IBiOsFactory
{
    public IBiOs CreateBiOs(int version, IList<string> supportedCpus)
    {
        return new MotherboardBios(version, supportedCpus);
    }
}