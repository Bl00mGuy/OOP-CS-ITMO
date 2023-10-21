using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ComputerValidationAnalysis
{
    private bool _getSupportedCoolingSystemSocket;
    private bool _getSupportedCpu;
    private bool _getSupportedDdrFrequency;
    private bool _getSupportedCaseFormFactor;

    public ComputerValidationAnalysis(Computer computer)
    {
        ValidationResult result = ValidateComputer(computer);
        IsValid = result.Valid;
        Status = result.Status;
    }

    public bool IsValid { get; }
    public AnalizatorStatus Status { get; }

    private ValidationResult ValidateComputer(Computer computer)
    {
        var totalResult = new ValidationResult(true, AnalizatorStatus.Valid);

        if (computer is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingComputer);
            return result;
        }

        if (computer.ComputerCpu is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCpu);
            return result;
        }

        if (computer.ComputerMotherboard is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingMotherboard);
            return result;
        }

        if (computer.ComputerCoolingSystem is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCoolingSystem);
            return result;
        }

        if (computer.ComputerDdr is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingDdr);
            return result;
        }

        if (computer.ComputerGpu is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingGpu);
            return result;
        }

        if (computer.ComputerSsd is null && computer.ComputerHdd is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingStorage);
            return result;
        }

        if (computer.ComputerCase is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCase);
            return result;
        }

        if (computer.ComputerPowerSupply is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingPowerSupply);
            return result;
        }

        if (computer.ComputerWiFi is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingWifi);
            return result;
        }

        // Check cooling system
        foreach (ICpu coolingSystemSocket in computer.ComputerCoolingSystem.SupportedSockets)
        {
            if (computer.ComputerCpu == coolingSystemSocket)
            {
                _getSupportedCoolingSystemSocket = true;

                // Check tdp of cpu and tdp of cooling system
                if (computer.ComputerCpu.ThermalDesignPower < computer.ComputerCoolingSystem.MaxThermalDesignPower)
                {
                    var result = new ValidationResult(false, AnalizatorStatus.InsufficientCoolingSystemTdp);
                    return result;
                }
            }
        }

        if (_getSupportedCoolingSystemSocket is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingRequiredCoolingSystem);
            return result;
        }

        // Check case
        if (computer.ComputerCase.DimensionsOfGpu.Height < computer.ComputerGpu.DimensionsOfVideoCard.Height || computer.ComputerCase.DimensionsOfGpu.Width < computer.ComputerGpu.DimensionsOfVideoCard.Width)
        {
            var result = new ValidationResult(false, AnalizatorStatus.TooBigGpu);
            return result;
        }

        foreach (MotherboardFormFactor formFactor in computer.ComputerCase.SupportedMotherboards)
        {
            if (computer.ComputerMotherboard.FormFactor == formFactor)
            {
                _getSupportedCaseFormFactor = true;
            }
        }

        if (_getSupportedCaseFormFactor is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.InaccessibleCaseFormFactor);
            return result;
        }

        // Check power supply
        if (computer.ComputerPowerSupply.PeakLoad < (computer.ComputerCpu.PowerConsumption + computer.ComputerGpu.PowerConsumption + computer.ComputerDdr.PowerConsumption + computer.ComputerWiFi.PowerConsumption + computer.ComputerCoolingSystem.PowerConsumption))
        {
            var result = new ValidationResult(false, AnalizatorStatus.InsufficientPowerSupply);
            return result;
        }
        else
        {
            totalResult.SetRecommendedStatus(AnalizatorStatus.ExcessPowerSupply);
        }

        // Check cpu and motherboard
        if (computer.ComputerCpu != computer.ComputerMotherboard.Socket)
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleCpuSocket);
            return result;
        }

        foreach (string cpuName in computer.ComputerMotherboard.MotherboardBiOs.SupportedCpus)
        {
            if (computer.ComputerCpu.Name == cpuName)
            {
                _getSupportedCpu = true;
            }
        }

        if (_getSupportedCpu is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleCpuSocket);
            return result;
        }

        // Check ddr
        if (computer.ComputerMotherboard.RequiredDdrVersion != computer.ComputerDdr.DdrVersion)
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleDdrVersion);
            return result;
        }

        foreach (int freq in computer.ComputerMotherboard.MotherboardChipset.PossibleDdrFrequency)
        {
            if (computer.ComputerDdr.DdrFrequency == freq)
            {
                _getSupportedDdrFrequency = true;
            }
        }

        if (_getSupportedDdrFrequency is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.InaccessibleDdrFrequency);
            return result;
        }

        if (computer.ComputerDdr.DdrFrequency != computer.ComputerCpu.SupportedMemoryFrequencies)
        {
            var result = new ValidationResult(false, AnalizatorStatus.InaccessibleDdrFrequency);
            return result;
        }

        return totalResult;
    }
}