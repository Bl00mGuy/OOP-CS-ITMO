namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion4Factory : IWiFiAdapterFactory
{
    public IWiFi CreateWiFiAdapter(string? name, int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        return new WiFiAdapterPciExpressVersion4(name, wifiStandardVersion, hasBluetooth, powerConsumption);
    }
}