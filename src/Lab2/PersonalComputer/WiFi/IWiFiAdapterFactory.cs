namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFiAdapterFactory
{
    IWiFi CreateWiFiAdapter(int wifiStandardVersion, bool hasBluetooth, int powerConsumption);
}