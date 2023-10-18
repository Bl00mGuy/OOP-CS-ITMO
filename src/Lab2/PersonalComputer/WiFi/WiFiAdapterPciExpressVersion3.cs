namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion3 : IWiFi
{
    public WiFiAdapterPciExpressVersion3(int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        WifiStandardVersion = wifiStandardVersion;
        HasBluetooth = hasBluetooth;
        PowerConsumption = powerConsumption;
    }

    public int WifiStandardVersion { get; }
    public bool HasBluetooth { get; }
    public int PowerConsumption { get; }
}