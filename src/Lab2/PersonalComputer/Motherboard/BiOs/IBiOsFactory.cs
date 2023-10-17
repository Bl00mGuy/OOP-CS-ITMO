using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;

public interface IBiOsFactory
{
    IBiOs CreateBiOs(string type, IList<ICpuFactory> supportedCpus);
}