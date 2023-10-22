using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class Computer
{
    public Computer(
        ICpu? computerCpu,
        IMotherboard? computerMotherboard,
        ICoolingSystem? computerCoolingSystem,
        IRam? computerDdr,
        IVideoCard? computerGpu,
        ISsd? computerSsd,
        IHdd? computerHdd,
        ICase? computerCase,
        IPowerSupply? computerPowerSupply,
        IWiFi? computerWiFi)
    {
        ComputerCpu = computerCpu;
        ComputerMotherboard = computerMotherboard;
        ComputerCoolingSystem = computerCoolingSystem;
        ComputerDdr = computerDdr;
        ComputerSsd = computerSsd;
        ComputerHdd = computerHdd;
        ComputerGpu = computerGpu;
        ComputerCase = computerCase;
        ComputerPowerSupply = computerPowerSupply;
        ComputerWiFi = computerWiFi;
    }

    public ICpu? ComputerCpu { get; private set; }
    public IMotherboard? ComputerMotherboard { get; private set; }
    public ICoolingSystem? ComputerCoolingSystem { get; private set; }
    public IRam? ComputerDdr { get; private set; }
    public IVideoCard? ComputerGpu { get; private set; }
    public ISsd? ComputerSsd { get; private set; }
    public IHdd? ComputerHdd { get; private set; }
    public ICase? ComputerCase { get; private set; }
    public IPowerSupply? ComputerPowerSupply { get; private set; }
    public IWiFi? ComputerWiFi { get; private set; }

    public Computer Clone()
    {
        return new Computer(
            ComputerCpu,
            ComputerMotherboard,
            ComputerCoolingSystem,
            ComputerDdr,
            ComputerGpu,
            ComputerSsd,
            ComputerHdd,
            ComputerCase,
            ComputerPowerSupply,
            ComputerWiFi);
    }

    public Computer SetComputerCpu(ICpu cpu)
    {
        Computer pcClone = Clone();

        pcClone.ComputerCpu = cpu;

        return pcClone;
    }

    public Computer SetComputerMotherboard(IMotherboard motherboard)
    {
        Computer pcClone = Clone();

        pcClone.ComputerMotherboard = motherboard;

        return pcClone;
    }

    public Computer SetComputerCoolingSystem(ICoolingSystem coolingSystem)
    {
        Computer pcClone = Clone();

        pcClone.ComputerCoolingSystem = coolingSystem;

        return pcClone;
    }

    public Computer SetComputerDdr(IRam ddr)
    {
        Computer pcClone = Clone();

        pcClone.ComputerDdr = ddr;

        return pcClone;
    }

    public Computer SetComputerGpu(IVideoCard gpu)
    {
        Computer pcClone = Clone();

        pcClone.ComputerGpu = gpu;

        return pcClone;
    }

    public Computer SetComputerSsd(ISsd ssd)
    {
        Computer pcClone = Clone();

        pcClone.ComputerSsd = ssd;

        return pcClone;
    }

    public Computer SetComputerHdd(ISsd ssd)
    {
        Computer pcClone = Clone();

        pcClone.ComputerSsd = ssd;

        return pcClone;
    }

    public Computer SetComputerCase(ICase computerCase)
    {
        Computer pcClone = Clone();

        pcClone.ComputerCase = computerCase;

        return pcClone;
    }

    public Computer SetComputerPowerSupply(IPowerSupply powerSupply)
    {
        Computer pcClone = Clone();

        pcClone.ComputerPowerSupply = powerSupply;

        return pcClone;
    }

    public Computer SetComputerWifi(IWiFi wifi)
    {
        Computer pcClone = Clone();

        pcClone.ComputerWiFi = wifi;

        return pcClone;
    }
}