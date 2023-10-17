namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFiAdapterFactory
{
    IWiFi CreateWiFiAdapter(string wifiStandardVersion, bool hasBluetooth, string pciExpressVersion, int powerConsumption);
}