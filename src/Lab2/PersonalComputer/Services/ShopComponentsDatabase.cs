using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ShopComponentsDatabase
{
    // Const
    private const int FirstGpuWidth = 155;
    private const int FirstGpuHeight = 130;

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
    private readonly Dimensions _secondGpuDimensions = new(FirstGpuWidth, FirstGpuHeight);
    private readonly int _secondGpuMemory = 24;
    private readonly int _secondGpuChipFrequency = 2235;
    private readonly int _secondGpuPowerConsumption = 1175;

    // HDD
    private readonly int _firstHddCapacity = 2000;
    private readonly int _firstHddSpindleSpeed = 7200;
    private readonly int _firstHddPowerConsumption = 34;

    // Sata SSD
    private readonly DriveConnectionType _firstSsdConnectionType = new SataConnectionType();
    private readonly int _firstSsdCapacity = 512;
    private readonly int _firstSsdMaxSpeed = 239;
    private readonly int _firstSsdPowerConsumption = 39;

    // PCI-E SSD
    private readonly DriveConnectionType _secondSsdConnectionType = new PciExpressConnectionType();
    private readonly int _secondSsdCapacity = 1024;
    private readonly int _secondSsdMaxSpeed = 241;
    private readonly int _secondSsdPowerConsumption = 41;

    // DDR3 DIMM
    private readonly int _firstDdrNumberOfPads = 2;
    private readonly int _firstDdrMemorySize = 16;
    private readonly int _firstDdrFrequency = 1600;
    private readonly RamFormFactor _firstDdrRamFormFactor = new DimmFormFactor();
    private readonly int _firstDdrPowerConsumption = 12;

    // DDR4 DIMM
    private readonly int _secondDdrNumberOfPads = 2;
    private readonly int _secondDdrMemorySize = 16;
    private readonly int _secondDdrFrequency = 3200;
    private readonly RamFormFactor _secondDdrRamFormFactor = new DimmFormFactor();
    private readonly int _secondDdrPowerConsumption = 14;

    // DDR5 DIMM
    private readonly int _thirdDdrNumberOfPads = 2;
    private readonly int _thirdDdrMemorySize = 16;
    private readonly int _thirdDdrFrequency = 5600;
    private readonly RamFormFactor _thirdDdrRamFormFactor = new DimmFormFactor();
    private readonly int _thirdDdrPowerConsumption = 16;

    // Power Supply
    private readonly int _firstPowerSupplyPeakLoad = 650;

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

        bool secondCpuHasIntegratedGraphics = true;
        _computerComponents.Add(new Am4(
            _secondCpuName,
            _secondCpuNumberOfCores,
            _secondCpuCoresFrequency,
            secondCpuHasIntegratedGraphics,
            _secondCpuMemoryFrequency,
            _secondCpuThermalDesignPower,
            _secondCpuPowerConsumption));

        bool thirdCpuHasIntegratedGraphics = false;
        _computerComponents.Add(new Am4(
            _thirdCpuName,
            _thirdCpuNumberOfCores,
            _thirdCpuCoresFrequency,
            thirdCpuHasIntegratedGraphics,
            _thirdCpuMemoryFrequency,
            _thirdCpuThermalDesignPower,
            _thirdCpuPowerConsumption));

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
            _firstHddCapacity,
            _firstHddSpindleSpeed,
            _firstHddPowerConsumption));

        _computerComponents.Add(new SolidStateDrive(
            _firstSsdConnectionType,
            _firstSsdCapacity,
            _firstSsdMaxSpeed,
            _firstSsdPowerConsumption));

        _computerComponents.Add(new SolidStateDrive(
            _secondSsdConnectionType,
            _secondSsdCapacity,
            _secondSsdMaxSpeed,
            _secondSsdPowerConsumption));

        _computerComponents.Add(new Ddr3(
            _firstDdrNumberOfPads,
            _firstDdrMemorySize,
            _firstDdrFrequency,
            _firstDdrRamFormFactor,
            _firstDdrPowerConsumption));

        _computerComponents.Add(new Ddr4(
            _secondDdrNumberOfPads,
            _secondDdrMemorySize,
            _secondDdrFrequency,
            _secondDdrRamFormFactor,
            _secondDdrPowerConsumption));

        _computerComponents.Add(new Ddr5(
            _thirdDdrNumberOfPads,
            _thirdDdrMemorySize,
            _thirdDdrFrequency,
            _thirdDdrRamFormFactor,
            _thirdDdrPowerConsumption));

        _computerComponents.Add(new PowerSupplyModel(
            _firstPowerSupplyPeakLoad));
    }
}