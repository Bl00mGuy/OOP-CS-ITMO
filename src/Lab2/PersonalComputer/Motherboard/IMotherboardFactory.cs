using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public interface IMotherboardFactory
{
    IMotherboard CreateMotherboard(string? name, ICpu socket, int countOfPciExpressPorts, int countOfSataPorts, MotherboardChipset chipset, DdrVersion ddr, int countOfRamPorts, MotherboardFormFactor formFactor, MotherboardBios bios);
}