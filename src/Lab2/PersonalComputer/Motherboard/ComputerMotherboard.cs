using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public class ComputerMotherboard : IMotherboard
{
    public ComputerMotherboard(ICpuFactory socket, int countOfPciExpressPorts, int countOfSataPorts, IChipset chipset, IRam ddr, int countOfRamPorts, MotherboardFormFactor formFactor, IBiOs bios)
    {
        Socket = socket;
        CountOfPciExpressPorts = countOfPciExpressPorts;
        CountOfSataPorts = countOfSataPorts;
        MotherboardChipset = chipset;
        RequiredDdrVersion = ddr;
        CountOfRamPorts = countOfRamPorts;
        FormFactor = formFactor;
        MotherboardBiOs = bios;
    }

    public ICpuFactory Socket { get; }
    public int CountOfPciExpressPorts { get; }
    public int CountOfSataPorts { get; }
    public IChipset MotherboardChipset { get; }
    public IRam RequiredDdrVersion { get; }
    public int CountOfRamPorts { get; }
    public MotherboardFormFactor FormFactor { get; }
    public IBiOs MotherboardBiOs { get; }
}