using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public class MotherboardFactory : IMotherboardFactory
{
    public IMotherboard CreateMotherboard(ICpu socket, int countOfPciExpressPorts, int countOfSataPorts, MotherboardChipset chipset, DdrVersion ddr, int countOfRamPorts, MotherboardFormFactor formFactor, MotherboardBios bios)
    {
        return new ComputerMotherboard(socket, countOfPciExpressPorts, countOfSataPorts, chipset, ddr, countOfRamPorts, formFactor, bios);
    }
}