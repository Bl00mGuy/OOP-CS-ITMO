namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapter : IWiFi
{
    public WiFiAdapter(string wifiStandardVersion, bool hasBluetooth, string pciExpressVersion, int powerConsumption)
    {
        WifiStandardVersion = wifiStandardVersion;
        HasBluetooth = hasBluetooth;
        PciExpressVersion = pciExpressVersion;
        PowerConsumption = powerConsumption;
    }

    public string WifiStandardVersion { get; }
    public bool HasBluetooth { get; }
    public string PciExpressVersion { get; }
    public int PowerConsumption { get; }
}