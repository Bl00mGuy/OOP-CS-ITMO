using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public interface IBiOsFactory
{
    IBiOs CreateBiOs(int version, IList<string> supportedCpus);
}