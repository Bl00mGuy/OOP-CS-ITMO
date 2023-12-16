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

public class ComputerBuilder : IComputerBuilder
{
    private static ICpu? _cpu;
    private IMotherboard? _motherboard;
    private ICoolingSystem? _coolingSystem;
    private IRam? _ram;
    private IVideoCard? _gpu;
    private ISsd? _ssd;
    private IHdd? _hdd;
    private ICase? _case;
    private IPowerSupply? _powerSupply;
    private IWiFi? _wifi;

    public IComputerBuilder WithCpu(ICpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder WithMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IComputerBuilder WithCoolingSystem(ICoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerBuilder WithDdr(IRam ddr)
    {
        _ram = ddr;
        return this;
    }

    public IComputerBuilder WithGpu(IVideoCard gpu)
    {
        _gpu = gpu;
        return this;
    }

    public IComputerBuilder WithSsd(ISsd ssd)
    {
        _ssd = ssd;
        return this;
    }

    public IComputerBuilder WithHdd(IHdd hdd)
    {
        _hdd = hdd;
        return this;
    }

    public IComputerBuilder WithCase(ICase computerCase)
    {
        _case = computerCase;
        return this;
    }

    public IComputerBuilder WithPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder WithWifi(IWiFi wifi)
    {
        _wifi = wifi;
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            _cpu,
            _motherboard,
            _coolingSystem,
            _ram,
            _gpu,
            _ssd,
            _hdd,
            _case,
            _powerSupply,
            _wifi);
    }
}