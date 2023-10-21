namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFiAdapterFactory
{
    IWiFi CreateWiFiAdapter(string? name, int wifiStandardVersion, bool hasBluetooth, int powerConsumption);
}