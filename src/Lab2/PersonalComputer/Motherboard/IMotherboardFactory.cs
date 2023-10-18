using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public interface IMotherboardFactory
{
    IMotherboard CreateMotherboard(ICpuFactory socket, int countOfPciExpressPorts, int countOfSataPorts, IChipset chipset, IRam ddr, int countOfRamPorts, MotherboardFormFactor formFactor, IBiOs bios);
}