using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public static class Program
{
    public static void Main()
    {
        ICpuFactory lga1700Factory = new Lga1700Factory();

        ICpu lga1700Cpu = lga1700Factory.CreateCpu("Intel i9", 8, 3600, true, DdrVersion.Ddr4, 3200, 95, 65);

        ICpuFactory lga1366Factory = new Lga1366Factory();

        ICpu lga1366Cpu = lga1366Factory.CreateCpu("Intel Xeon", 12, 2400, false, DdrVersion.Ddr3, 1333, 130, 95);

        Console.WriteLine("Processor 1:");
        PrintCpuInfo(lga1700Cpu);

        Console.WriteLine("\nProcessor 2:");
        PrintCpuInfo(lga1366Cpu);
    }

    private static void PrintCpuInfo(ICpu cpu)
    {
        Console.WriteLine($"CPU Name: {cpu.CpuName}");
        Console.WriteLine($"Number of Cores: {cpu.NumberOfCores}");
        Console.WriteLine($"Core Frequency: {cpu.CoresFrequency} GHz");
        Console.WriteLine($"Integrated Graphics: {cpu.HasIntegratedGraphics}");
        Console.WriteLine($"Supported Memory Version: {cpu.SupportedMemoryVersion}");
        Console.WriteLine($"Supported Memory Frequencies: {string.Join(", ", cpu.SupportedMemoryFrequencies)} MHz");
        Console.WriteLine($"Thermal Design Power (TDP): {cpu.ThermalDesignPower} W");
        Console.WriteLine($"Power Consumption: {cpu.PowerConsumption} W");
    }
}