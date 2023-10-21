using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard.BiOs;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ShopComponentsDatabase
{
    // Const
    private const int FirstGpuWidth = 155;
    private const int SecondGpuWidth = 175;
    private const int FirstGpuHeight = 130;
    private const int SecondGpuHeight = 150;
    private const int CoolerHeight = 100;
    private const int CoolerWidth = 86;
    private const int CaseHeight = 984;
    private const int CaseWidth = 939;
    private const int FirstPossibleDdrFrequency = 2400;
    private const int SecondPossibleDdrFrequency = 3200;
    private const int ThirdPossibleDdrFrequency = 5600;
    private const int FirstMotherboardBiosVersion = 1;
    private const string DefaultCpuName = "Motherboard Socket Initialization";
    private const int DefaultCpuNumberOfCores = 0;
    private const int DefaultCpuCoresFrequency = 0;
    private const bool DefaultCpuHasIntegratedGraphics = false;
    private const int DefaultCpuMemoryFrequency = 0;
    private const int DefaultCpuThermalDesignPower = 0;
    private const int DefaultCpuPowerConsumption = 0;

    private readonly ICollection<IComponent> _computerComponents = new List<IComponent>();

    // First CPU
    private readonly string _firstCpuName = "Ryzen 5 3600";
    private readonly int _firstCpuNumberOfCores = 6;
    private readonly int _firstCpuCoresFrequency = 3600;
    private readonly int _firstCpuMemoryFrequency = 3200;
    private readonly int _firstCpuThermalDesignPower = 65;
    private readonly int _firstCpuPowerConsumption = 65;

    // Second CPU
    private readonly string _secondCpuName = "Core i7-13700";
    private readonly int _secondCpuNumberOfCores = 8;
    private readonly int _secondCpuCoresFrequency = 3400;
    private readonly int _secondCpuMemoryFrequency = 5600;
    private readonly int _secondCpuThermalDesignPower = 253;
    private readonly int _secondCpuPowerConsumption = 253;

    // Third CPU
    private readonly string _thirdCpuName = "Xeon X5690";
    private readonly int _thirdCpuNumberOfCores = 6;
    private readonly int _thirdCpuCoresFrequency = 3460;
    private readonly int _thirdCpuMemoryFrequency = 1600;
    private readonly int _thirdCpuThermalDesignPower = 130;
    private readonly int _thirdCpuPowerConsumption = 130;

    // First GPU
    private readonly string _firstGpuName = "GTX 1660";
    private readonly Dimensions _firstGpuDimensions = new(FirstGpuWidth, FirstGpuHeight);
    private readonly int _firstGpuMemory = 6;
    private readonly int _firstGpuChipFrequency = 1530;
    private readonly int _firstGpuPowerConsumption = 250;

    // Second GPU
    private readonly string _secondGpuName = "RTX 4090";
    private readonly Dimensions _secondGpuDimensions = new(SecondGpuWidth, SecondGpuHeight);
    private readonly int _secondGpuMemory = 24;
    private readonly int _secondGpuChipFrequency = 2235;
    private readonly int _secondGpuPowerConsumption = 1175;

    // HDD
    private readonly string _firstHddName = "Seagate BarraCuda";
    private readonly int _firstHddCapacity = 2000;
    private readonly int _firstHddSpindleSpeed = 7200;
    private readonly int _firstHddPowerConsumption = 34;

    // Sata SSD
    private readonly string _firstSsdName = "Samsung 870 EVO";
    private readonly DriveConnectionType _firstSsdConnectionType = new SataConnectionType();
    private readonly int _firstSsdCapacity = 512;
    private readonly int _firstSsdMaxSpeed = 239;
    private readonly int _firstSsdPowerConsumption = 39;

    // PCI-E SSD
    private readonly string _secondSsdName = "Samsung 980 PRO";
    private readonly DriveConnectionType _secondSsdConnectionType = new PciExpressConnectionType();
    private readonly int _secondSsdCapacity = 1024;
    private readonly int _secondSsdMaxSpeed = 241;
    private readonly int _secondSsdPowerConsumption = 41;

    // DDR3 DIMM
    private readonly string _firstDdrName = "GSkill AEGIS DDR3";
    private readonly int _firstDdrNumberOfPads = 2;
    private readonly int _firstDdrMemorySize = 16;
    private readonly DdrVersion _firstDdrVersion = new Ddr3();
    private readonly int _firstDdrFrequency = 1600;
    private readonly RamFormFactor _firstDdrRamFormFactor = new DimmFormFactor();
    private readonly int _firstDdrPowerConsumption = 12;

    // DDR4 DIMM
    private readonly string _secondDdrName = "GSkill AEGIS DDR4";
    private readonly int _secondDdrNumberOfPads = 2;
    private readonly int _secondDdrMemorySize = 16;
    private readonly DdrVersion _secondDdrVersion = new Ddr4();
    private readonly int _secondDdrFrequency = 3200;
    private readonly RamFormFactor _secondDdrRamFormFactor = new DimmFormFactor();
    private readonly int _secondDdrPowerConsumption = 14;

    // DDR5 DIMM
    private readonly string _thirdDdrName = "GSkill AEGIS DDR5";
    private readonly int _thirdDdrNumberOfPads = 2;
    private readonly int _thirdDdrMemorySize = 16;
    private readonly DdrVersion _thirdDdrVersion = new Ddr5();
    private readonly int _thirdDdrFrequency = 5600;
    private readonly RamFormFactor _thirdDdrRamFormFactor = new DimmFormFactor();
    private readonly int _thirdDdrPowerConsumption = 16;

    // DDR3 SODIMM
    private readonly string _fourthDdrName = "GSkill AEGIS DDR3 SODIMM";
    private readonly int _fourthDdrNumberOfPads = 2;
    private readonly int _fourthDdrMemorySize = 16;
    private readonly DdrVersion _fourthDdrVersion = new Ddr3();
    private readonly int _fourthDdrFrequency = 1600;
    private readonly RamFormFactor _fourthDdrRamFormFactor = new SoDimmFormFactor();
    private readonly int _fourthDdrPowerConsumption = 12;

    // DDR4 SODIMM
    private readonly string _fifthDdrName = "GSkill AEGIS DDR4 SODIMM";
    private readonly int _fifthDdrNumberOfPads = 2;
    private readonly int _fifthDdrMemorySize = 16;
    private readonly DdrVersion _fifthDdrVersion = new Ddr4();
    private readonly int _fifthDdrFrequency = 3200;
    private readonly RamFormFactor _fifthDdrRamFormFactor = new SoDimmFormFactor();
    private readonly int _fifthDdrPowerConsumption = 14;

    // DDR5 SODIMM
    private readonly string _sixthDdrName = "GSkill AEGIS DDR5 SODIMM";
    private readonly int _sixthDdrNumberOfPads = 2;
    private readonly int _sixthDdrMemorySize = 16;
    private readonly DdrVersion _sixthDdrVersion = new Ddr5();
    private readonly int _sixthDdrFrequency = 5600;
    private readonly RamFormFactor _sixthDdrRamFormFactor = new SoDimmFormFactor();
    private readonly int _sixthDdrPowerConsumption = 16;

    // Power Supply
    private readonly string _firstPowerSupplyName = "beQuiet 850";
    private readonly int _firstPowerSupplyPeakLoad = 850;

    // Motherboard AM4
    private readonly string _firstMotherboardName = "MSI B450 GAMING GIGA MEGA PLUS MAX";
    private readonly int _firstMotherboardCountOfPciExpressPorts = 2;
    private readonly int _firstMotherboardCountOfSataPorts = 2;
    private readonly DdrVersion _firstMotherboardDdrVersion = new Ddr4();
    private readonly int _firstMotherboardCountOfRamPorts = 4;
    private readonly MotherboardFormFactor _firstMotherboardFormFactor = MotherboardFormFactor.MicroAtx;

    // Motherboard Lga1700
    private readonly string _secondMotherboardName = "ASUS X99 GAMING GIGA MEGA PLUS MAX";
    private readonly int _secondMotherboardCountOfPciExpressPorts = 4;
    private readonly int _secondMotherboardCountOfSataPorts = 6;
    private readonly DdrVersion _secondMotherboardDdrVersion = new Ddr5();
    private readonly int _secondMotherboardCountOfRamPorts = 8;
    private readonly MotherboardFormFactor _secondMotherboardFormFactor = MotherboardFormFactor.MiniAtx;

    // Motherboard Lga1366
    private readonly string _thirdMotherboardName = "CHINA X999 GAMING BOARD";
    private readonly int _thirdMotherboardCountOfPciExpressPorts = 6;
    private readonly int _thirdMotherboardCountOfSataPorts = 6;
    private readonly DdrVersion _thirdMotherboardDdrVersion = new Ddr3();
    private readonly int _thirdMotherboardCountOfRamPorts = 4;
    private readonly MotherboardFormFactor _thirdMotherboardFormFactor = MotherboardFormFactor.Atx;

    // First cooler
    private readonly string _firstCoolerName = "Deepcool WB442";
    private readonly Dimensions _firstCoolerDimensions = new Dimensions(CoolerWidth, CoolerHeight);
    private readonly int _firstCoolerTdp = 50;
    private readonly int _firstCoolerPowerConsumption = 10;

    // Second cooler
    private readonly string _secondCoolerName = "Deepcool XHD992";
    private readonly Dimensions _secondCoolerDimensions = new Dimensions(CoolerWidth, CoolerHeight);
    private readonly int _secondCoolerTdp = 350;
    private readonly int _secondCoolerPowerConsumption = 12;

    // Case
    private readonly string _firstCaseName = "NZXT BBW32";
    private readonly Dimensions _firstCaseDimensions = new Dimensions(CaseWidth, CaseHeight);
    private readonly Dimensions _firstCaseGpuDimensions = new Dimensions(CaseWidth, CaseHeight);

    private readonly string _firstWifiModuleName = "Intel Accelo Wifi Module";
    private readonly int _firstWifiModuleVersion = 811;
    private readonly bool _firstWifiModuleHasBluetooth = true;
    private readonly int _firstWifiModulePowerConsumption = 4;

    public ShopComponentsDatabase()
    {
        bool firstCpuHasIntegratedGraphics = false;
        _computerComponents.Add(new Am4(
            _firstCpuName,
            _firstCpuNumberOfCores,
            _firstCpuCoresFrequency,
            firstCpuHasIntegratedGraphics,
            _firstCpuMemoryFrequency,
            _firstCpuThermalDesignPower,
            _firstCpuPowerConsumption));

        IList<int> firstMotherboardPossibleDdrFrequency = new List<int> { SecondPossibleDdrFrequency };
        var firstMotherboardChipset = new MotherboardChipset(firstMotherboardPossibleDdrFrequency);
        IList<string> firstMotherboardBiosSupportedCpu = new List<string> { "Ryzen 5 3600" };
        var firstMotherboardBios = new MotherboardBios(FirstMotherboardBiosVersion, firstMotherboardBiosSupportedCpu);
        _computerComponents.Add(new ComputerMotherboard(
            _firstMotherboardName,
            new Am4(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption),
            _firstMotherboardCountOfPciExpressPorts,
            _firstMotherboardCountOfSataPorts,
            firstMotherboardChipset,
            _firstMotherboardDdrVersion,
            _firstMotherboardCountOfRamPorts,
            _firstMotherboardFormFactor,
            firstMotherboardBios));

        bool secondCpuHasIntegratedGraphics = true;
        _computerComponents.Add(new Lga1700(
            _secondCpuName,
            _secondCpuNumberOfCores,
            _secondCpuCoresFrequency,
            secondCpuHasIntegratedGraphics,
            _secondCpuMemoryFrequency,
            _secondCpuThermalDesignPower,
            _secondCpuPowerConsumption));

        IList<int> secondMotherboardPossibleDdrFrequency = new List<int> { ThirdPossibleDdrFrequency };
        var secondMotherboardChipset = new MotherboardChipset(secondMotherboardPossibleDdrFrequency);
        IList<string> secondMotherboardBiosSupportedCpu = new List<string> { "Ryzen 5 3600" };
        var secondMotherboardBios = new MotherboardBios(FirstMotherboardBiosVersion, secondMotherboardBiosSupportedCpu);
        _computerComponents.Add(new ComputerMotherboard(
            _secondMotherboardName,
            new Lga1700(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption),
            _secondMotherboardCountOfPciExpressPorts,
            _secondMotherboardCountOfSataPorts,
            secondMotherboardChipset,
            _secondMotherboardDdrVersion,
            _secondMotherboardCountOfRamPorts,
            _secondMotherboardFormFactor,
            secondMotherboardBios));

        bool thirdCpuHasIntegratedGraphics = false;
        _computerComponents.Add(new Lga1366(
            _thirdCpuName,
            _thirdCpuNumberOfCores,
            _thirdCpuCoresFrequency,
            thirdCpuHasIntegratedGraphics,
            _thirdCpuMemoryFrequency,
            _thirdCpuThermalDesignPower,
            _thirdCpuPowerConsumption));

        IList<int> thirdMotherboardPossibleDdrFrequency = new List<int> { FirstPossibleDdrFrequency };
        var thirdMotherboardChipset = new MotherboardChipset(thirdMotherboardPossibleDdrFrequency);
        IList<string> thirdMotherboardBiosSupportedCpu = new List<string> { "Ryzen 5 3600" };
        var thirdMotherboardBios = new MotherboardBios(FirstMotherboardBiosVersion, thirdMotherboardBiosSupportedCpu);
        _computerComponents.Add(new ComputerMotherboard(
            _thirdMotherboardName,
            new Lga1700(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption),
            _thirdMotherboardCountOfPciExpressPorts,
            _thirdMotherboardCountOfSataPorts,
            thirdMotherboardChipset,
            _thirdMotherboardDdrVersion,
            _thirdMotherboardCountOfRamPorts,
            _thirdMotherboardFormFactor,
            thirdMotherboardBios));

        _computerComponents.Add(new GpuPciExpressVersion3(
            _firstGpuName,
            _firstGpuDimensions,
            _firstGpuMemory,
            _firstGpuChipFrequency,
            _firstGpuPowerConsumption));

        _computerComponents.Add(new GpuPciExpressVersion4(
            _secondGpuName,
            _secondGpuDimensions,
            _secondGpuMemory,
            _secondGpuChipFrequency,
            _secondGpuPowerConsumption));

        _computerComponents.Add(new HardDiskDrive(
            _firstHddName,
            _firstHddCapacity,
            _firstHddSpindleSpeed,
            _firstHddPowerConsumption));

        _computerComponents.Add(new SolidStateDrive(
            _firstSsdName,
            _firstSsdConnectionType,
            _firstSsdCapacity,
            _firstSsdMaxSpeed,
            _firstSsdPowerConsumption));

        _computerComponents.Add(new SolidStateDrive(
            _secondSsdName,
            _secondSsdConnectionType,
            _secondSsdCapacity,
            _secondSsdMaxSpeed,
            _secondSsdPowerConsumption));

        _computerComponents.Add(new Ram(
            _firstDdrName,
            _firstDdrNumberOfPads,
            _firstDdrMemorySize,
            _firstDdrVersion,
            _firstDdrFrequency,
            _firstDdrRamFormFactor,
            _firstDdrPowerConsumption));

        _computerComponents.Add(new Ram(
            _secondDdrName,
            _secondDdrNumberOfPads,
            _secondDdrMemorySize,
            _secondDdrVersion,
            _secondDdrFrequency,
            _secondDdrRamFormFactor,
            _secondDdrPowerConsumption));

        _computerComponents.Add(new Ram(
            _thirdDdrName,
            _thirdDdrNumberOfPads,
            _thirdDdrMemorySize,
            _thirdDdrVersion,
            _thirdDdrFrequency,
            _thirdDdrRamFormFactor,
            _thirdDdrPowerConsumption));

        _computerComponents.Add(new Ram(
            _fourthDdrName,
            _fourthDdrNumberOfPads,
            _fourthDdrMemorySize,
            _fourthDdrVersion,
            _fourthDdrFrequency,
            _fourthDdrRamFormFactor,
            _fourthDdrPowerConsumption));

        _computerComponents.Add(new Ram(
            _fifthDdrName,
            _fifthDdrNumberOfPads,
            _fifthDdrMemorySize,
            _fifthDdrVersion,
            _fifthDdrFrequency,
            _fifthDdrRamFormFactor,
            _fifthDdrPowerConsumption));

        _computerComponents.Add(new Ram(
            _sixthDdrName,
            _sixthDdrNumberOfPads,
            _sixthDdrMemorySize,
            _sixthDdrVersion,
            _sixthDdrFrequency,
            _sixthDdrRamFormFactor,
            _sixthDdrPowerConsumption));

        _computerComponents.Add(new PowerSupplyModel(
            _firstPowerSupplyName,
            _firstPowerSupplyPeakLoad));

        var supportedCpus = new List<ICpu> { new Lga1700(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption), new Lga1366(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption), new Am4(DefaultCpuName, DefaultCpuNumberOfCores, DefaultCpuCoresFrequency, DefaultCpuHasIntegratedGraphics, DefaultCpuMemoryFrequency, DefaultCpuThermalDesignPower, DefaultCpuPowerConsumption), };
        _computerComponents.Add(new CpuCoolingSystem(
            _firstCoolerName,
            _firstCoolerDimensions,
            supportedCpus,
            _firstCoolerTdp,
            _firstCoolerPowerConsumption));

        _computerComponents.Add(new CpuCoolingSystem(
            _secondCoolerName,
            _secondCoolerDimensions,
            supportedCpus,
            _secondCoolerTdp,
            _secondCoolerPowerConsumption));

        var caseSuppotedMotherboardFormFactor = new List<MotherboardFormFactor> { MotherboardFormFactor.Atx, MotherboardFormFactor.MicroAtx, MotherboardFormFactor.MiniAtx };
        _computerComponents.Add(new ComputerCase.ComputerCase(
            _firstCaseName,
            _firstCaseDimensions,
            _firstCaseGpuDimensions,
            caseSuppotedMotherboardFormFactor));

        _computerComponents.Add(new WiFiAdapterPciExpressVersion3(
            _firstWifiModuleName,
            _firstWifiModuleVersion,
            _firstWifiModuleHasBluetooth,
            _firstWifiModulePowerConsumption));
    }

    public IComponent? Find(string name)
    {
        return _computerComponents.FirstOrDefault(x => x.Name == name);
    }

    public void Update(IComponent component)
    {
        _computerComponents.Add(component);
    }
}