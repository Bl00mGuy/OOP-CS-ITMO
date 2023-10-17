namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFi
{
    string WifiStandardVersion { get; }
    bool HasBluetooth { get; }
    string PciExpressVersion { get; }
    int PowerConsumption { get; }
}