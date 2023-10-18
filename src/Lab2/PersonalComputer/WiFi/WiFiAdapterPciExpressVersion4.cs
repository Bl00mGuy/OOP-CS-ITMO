namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion4 : IWiFi
{
    public WiFiAdapterPciExpressVersion4(int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        WifiStandardVersion = wifiStandardVersion;
        HasBluetooth = hasBluetooth;
        PowerConsumption = powerConsumption;
    }

    public int WifiStandardVersion { get; }
    public bool HasBluetooth { get; }
    public int PowerConsumption { get; }
}