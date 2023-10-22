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

public interface IComputerBuilder
{
    IComputerBuilder WithCpu(ICpu cpu);

    IComputerBuilder WithMotherboard(IMotherboard motherboard);

    IComputerBuilder WithCoolingSystem(ICoolingSystem coolingSystem);

    IComputerBuilder WithDdr(IRam ddr);

    IComputerBuilder WithGpu(IVideoCard gpu);

    IComputerBuilder WithSsd(ISsd ssd);

    IComputerBuilder WithHdd(IHdd hdd);

    IComputerBuilder WithCase(ICase computerCase);

    IComputerBuilder WithPowerSupply(IPowerSupply powerSupply);

    IComputerBuilder WithWifi(IWiFi wifi);

    Computer Build();
}