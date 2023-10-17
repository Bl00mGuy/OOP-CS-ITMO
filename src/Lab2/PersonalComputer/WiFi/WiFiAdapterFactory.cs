namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterFactory : IWiFiAdapterFactory
{
    public IWiFi CreateWiFiAdapter(string wifiStandardVersion, bool hasBluetooth, string pciExpressVersion, int powerConsumption)
    {
        return new WiFiAdapter(wifiStandardVersion, hasBluetooth, pciExpressVersion, powerConsumption);
    }
}