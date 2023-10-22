using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

public class ComputerMotherboard : IMotherboard
{
    public ComputerMotherboard(string? name, ICpu socket, int countOfPciExpressPorts, int countOfSataPorts, MotherboardChipset chipset, DdrVersion ddr, int countOfRamPorts, MotherboardFormFactor formFactor, MotherboardBios bios)
    {
        Name = name;
        Socket = socket;
        CountOfPciExpressPorts = countOfPciExpressPorts;
        CountOfSataPorts = countOfSataPorts;
        MotherboardChipset = chipset;
        RequiredDdrVersion = ddr;
        CountOfRamPorts = countOfRamPorts;
        FormFactor = formFactor;
        MotherboardBiOs = bios;
    }

    public string? Name { get; private set; }
    public ICpu Socket { get; private set; }
    public int CountOfPciExpressPorts { get; private set; }
    public int CountOfSataPorts { get; private set; }
    public MotherboardChipset MotherboardChipset { get; private set; }
    public DdrVersion RequiredDdrVersion { get; private set; }
    public int CountOfRamPorts { get; private set; }
    public MotherboardFormFactor FormFactor { get; private set; }
    public MotherboardBios MotherboardBiOs { get; private set; }

    public ComputerMotherboard Clone()
    {
        return new ComputerMotherboard(
            Name,
            Socket,
            CountOfPciExpressPorts,
            CountOfSataPorts,
            MotherboardChipset,
            RequiredDdrVersion,
            CountOfRamPorts,
            FormFactor,
            MotherboardBiOs);
    }

    public ComputerMotherboard SetMotherboardName(string name)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.Name = name;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardSocket(ICpu socket)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.Socket = socket;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardCountOfPciExpressPorts(int countOfPciExpressPorts)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.CountOfPciExpressPorts = countOfPciExpressPorts;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardCountOfSataPorts(int countOfSataPorts)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.CountOfSataPorts = countOfSataPorts;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardMotherboardChipset(MotherboardChipset motherboardChipset)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.MotherboardChipset = motherboardChipset;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardRequiredDdrVersion(DdrVersion requiredDdrVersion)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.RequiredDdrVersion = requiredDdrVersion;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardCountOfRamPorts(int countOfRamPorts)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.CountOfRamPorts = countOfRamPorts;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardFormFactor(MotherboardFormFactor formFactor)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.FormFactor = formFactor;

        return cloneMotherboard;
    }

    public ComputerMotherboard SetMotherboardMotherboardBiOs(MotherboardBios motherboardBiOs)
    {
        ComputerMotherboard cloneMotherboard = Clone();

        cloneMotherboard.MotherboardBiOs = motherboardBiOs;

        return cloneMotherboard;
    }
}