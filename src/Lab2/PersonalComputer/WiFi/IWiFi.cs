namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFi
{
    int WifiStandardVersion { get; }
    bool HasBluetooth { get; }
    int PowerConsumption { get; }
}