namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterFactory : IWiFiAdapterFactory
{
    public IWiFi CreateWiFiAdapter(int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        return new WiFiAdapter(wifiStandardVersion, hasBluetooth, powerConsumption);
    }
}