using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.CentralProcessingUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ComputerValidationAnalysis
{
    private bool _getSupportedCoolingSystemSocket;
    private bool _getSupportedCpu;
    private bool _getSupportedDdrFrequency;
    private ValidationResult _initialResult;

    public ComputerValidationAnalysis(Computer computer)
    {
        _initialResult = new ValidationResult(true, AnalizatorStatus.Valid, RecommendationStatus.Absent);
        ValidationResult result = ValidateComputer(computer);
        IsValid = result.Valid;
        Status = result.Status;
    }

    public bool IsValid { get; }
    public AnalizatorStatus Status { get; }

    private ValidationResult ValidateComputer(Computer computer)
    {
        const RecommendationStatus withoutRecommendation = RecommendationStatus.Absent;

        if (computer.ComputerCpu is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCpu, withoutRecommendation);
            return result;
        }

        if (computer.ComputerMotherboard is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingMotherboard, withoutRecommendation);
            return result;
        }

        if (computer.ComputerCoolingSystem is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCoolingSystem, withoutRecommendation);
            return result;
        }

        if (computer.ComputerDdr is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingDdr, withoutRecommendation);
            return result;
        }

        if (computer.ComputerGpu is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingGpu, withoutRecommendation);
            return result;
        }

        if (computer.ComputerSsd is null && computer.ComputerHdd is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingStorage, withoutRecommendation);
            return result;
        }

        if (computer.ComputerCase is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingCase, withoutRecommendation);
            return result;
        }

        if (computer.ComputerPowerSupply is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingPowerSupply, withoutRecommendation);
            return result;
        }

        if (computer.ComputerWiFi is null)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingWifi, withoutRecommendation);
            return result;
        }

        // Check case
        if (computer.ComputerCase.DimensionsOfGpu.Height < computer.ComputerGpu.DimensionsOfVideoCard.Height || computer.ComputerCase.DimensionsOfGpu.Width < computer.ComputerGpu.DimensionsOfVideoCard.Width)
        {
            var result = new ValidationResult(false, AnalizatorStatus.TooBigGpu, withoutRecommendation);
            return result;
        }

        // Check cooling system
        foreach (ICpu coolingSystemSocket in computer.ComputerCoolingSystem.SupportedSockets)
        {
            if (computer.ComputerCpu.Equally(coolingSystemSocket))
            {
                _getSupportedCoolingSystemSocket = true;

                // Check tdp of cpu and tdp of cooling system
                if (computer.ComputerCpu.ThermalDesignPower > computer.ComputerCoolingSystem.MaxThermalDesignPower)
                {
                    var result = new ValidationResult(false, AnalizatorStatus.InsufficientCoolingSystemTdp, withoutRecommendation);
                    return result;
                }
            }
        }

        if (_getSupportedCoolingSystemSocket is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.MissingRequiredCoolingSystem, withoutRecommendation);
            return result;
        }

        // Check cpu and motherboard
        if (computer.ComputerCpu.Equally(computer.ComputerMotherboard.Socket) is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleCpuSocket, withoutRecommendation);
            return result;
        }

        foreach (string cpuName in computer.ComputerMotherboard.MotherboardBiOs.SupportedCpus)
        {
            if (computer.ComputerCpu.Name is not null && computer.ComputerCpu.Name.Equals(cpuName, System.StringComparison.Ordinal))
            {
                _getSupportedCpu = true;
            }
        }

        if (_getSupportedCpu is not true)
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleCpuSocket, withoutRecommendation);
            return result;
        }

        // Check ddr
        if (computer.ComputerMotherboard.RequiredDdrVersion.Name != null && computer.ComputerMotherboard.RequiredDdrVersion.Name.Equals(computer.ComputerDdr.DdrVersion.Name, System.StringComparison.Ordinal))
        {
            var result = new ValidationResult(false, AnalizatorStatus.IncompatibleDdrVersion, withoutRecommendation);
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
            var result = new ValidationResult(false, AnalizatorStatus.InaccessibleDdrFrequency, withoutRecommendation);
            return result;
        }

        if (computer.ComputerDdr.DdrFrequency != computer.ComputerCpu.SupportedMemoryFrequencies)
        {
            var result = new ValidationResult(false, AnalizatorStatus.InaccessibleDdrFrequency, withoutRecommendation);
            return result;
        }

        // Check power supply
        if (computer.ComputerPowerSupply.PeakLoad < (computer.ComputerCpu.PowerConsumption + computer.ComputerGpu.PowerConsumption + computer.ComputerDdr.PowerConsumption + computer.ComputerWiFi.PowerConsumption + computer.ComputerCoolingSystem.PowerConsumption))
        {
            var result = new ValidationResult(false, AnalizatorStatus.InsufficientPowerSupply, withoutRecommendation);
            return result;
        }
        else
        {
            _initialResult = new ValidationResult(true, AnalizatorStatus.Valid, RecommendationStatus.ExcessPowerSupply);
        }

        return _initialResult;
    }
}