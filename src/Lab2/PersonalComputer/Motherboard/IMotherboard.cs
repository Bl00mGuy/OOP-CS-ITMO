using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public interface IMotherboard : IComponent
{
    ICpu Socket { get; }
    int CountOfPciExpressPorts { get; }
    int CountOfSataPorts { get; }
    MotherboardChipset MotherboardChipset { get; }
    DdrVersion RequiredDdrVersion { get; }
    int CountOfRamPorts { get; }
    MotherboardFormFactor FormFactor { get; }
    MotherboardBios MotherboardBiOs { get; }
}