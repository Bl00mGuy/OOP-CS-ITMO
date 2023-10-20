namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class ComputerValidationAnalysis
{
    public AnalizatorStatus ValidateComputer(Computer computer)
    {
        if (computer is null)
            return AnalizatorStatus.MissingComputer;
        if (computer.ComputerCpu is null)
            return AnalizatorStatus.MissingCpu;
        if (computer.ComputerMotherboard is null)
            return AnalizatorStatus.MissingMotherboard;
        if (computer.ComputerCoolingSystem is null)
            return AnalizatorStatus.MissingCoolingSystem;
        if (computer.ComputerDdr is null)
            return AnalizatorStatus.MissingDdr;
        if (computer.ComputerGpu is null)
            return AnalizatorStatus.MissingGpu;
        if (computer.ComputerSsd is null && computer.ComputerHdd is null)
            return AnalizatorStatus.MissingStorage;
        if (computer.ComputerCase is null)
            return AnalizatorStatus.MissingCase;
        if (computer.ComputerPowerSupply is null)
            return AnalizatorStatus.MissingPowerSupply;
        if (computer.ComputerWiFi is null)
            return AnalizatorStatus.MissingWifi;
    }
}