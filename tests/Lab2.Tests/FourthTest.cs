using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.GraphicsProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FourthTest
{
    public static IEnumerable<object[]> TestParameters()
    {
        var database = new Repository();

        IComponent? cpu = database.FindComponent("Ryzen 5 3600");
        IComponent? motherboard = database.FindComponent("CHINA X999 GAMING BOARD");
        IComponent? coolingSystem = database.FindComponent("Deepcool WB442");
        IComponent? ddr = database.FindComponent("GSkill AEGIS DDR3");
        IComponent? gpu = database.FindComponent("GTX 1660");
        IComponent? ssd = database.FindComponent("Samsung 870 EVO");
        IComponent? hdd = database.FindComponent("Seagate BarraCuda");
        IComponent? pcCase = database.FindComponent("NZXT BBW32");
        IComponent? powerSupply = database.FindComponent("beQuiet 850");
        IComponent? wifi = database.FindComponent("Intel Accelo Wifi Module");

        if (cpu is not null)
        {
            if (motherboard is not null)
            {
                if (coolingSystem is not null)
                {
                    if (ddr is not null)
                    {
                        if (gpu is not null)
                        {
                            if (ssd is not null)
                            {
                                if (hdd is not null)
                                {
                                    if (pcCase is not null)
                                    {
                                        if (powerSupply is not null)
                                        {
                                            if (wifi is not null)
                                            {
                                                yield return new object[] { cpu, motherboard, coolingSystem, ddr, gpu, ssd, hdd, pcCase, powerSupply, wifi };
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void TestPc(ICpu cpu, IMotherboard motherboard, ICoolingSystem coolingSystem, IRam ddr, IVideoCard gpu, ISsd ssd, IHdd hdd, ICase pcCase, IPowerSupply powerSupply, IWiFi wifi)
    {
        // Arrange
        IComputerBuilder computerBuilder = new ComputerBuilder().WithCpu(cpu).WithMotherboard(motherboard).WithCoolingSystem(coolingSystem).WithDdr(ddr).WithGpu(gpu).WithSsd(ssd).WithHdd(hdd).WithCase(pcCase).WithPowerSupply(powerSupply).WithWifi(wifi);
        Computer computer = computerBuilder.Build();

        const AnalizatorStatus expectedOutput = AnalizatorStatus.IncompatibleCpuSocket;

        // Act
        var result = new ComputerValidationAnalysis(computer);

        // Assert
        Assert.Equal(expectedOutput, result.Status);
    }
}