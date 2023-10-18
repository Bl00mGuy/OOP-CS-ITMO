namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion3Factory : IWiFiAdapterFactory
{
    public IWiFi CreateWiFiAdapter(int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        return new WiFiAdapterPciExpressVersion3(wifiStandardVersion, hasBluetooth, powerConsumption);
    }
}