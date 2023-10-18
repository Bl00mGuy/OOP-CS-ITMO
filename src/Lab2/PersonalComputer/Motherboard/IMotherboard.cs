using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public interface IMotherboard
{
    ICpuFactory Socket { get; }
    int CountOfPciExpressPorts { get; }
    int CountOfSataPorts { get; }
    IChipset MotherboardChipset { get; }
    IRam RequiredDdrVersion { get; }
    int CountOfRamPorts { get; }
    MotherboardFormFactor FormFactor { get; }
    IBiOs MotherboardBiOs { get; }
}