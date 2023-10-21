namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion4 : IWiFi
{
    public WiFiAdapterPciExpressVersion4(string? name, int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
    {
        Name = name;
        WifiStandardVersion = wifiStandardVersion;
        HasBluetooth = hasBluetooth;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }
    public int WifiStandardVersion { get; private set; }
    public bool HasBluetooth { get; private set; }
    public int PowerConsumption { get; private set; }

    public WiFiAdapterPciExpressVersion4 Clone()
    {
        return new WiFiAdapterPciExpressVersion4(
            Name,
            WifiStandardVersion,
            HasBluetooth,
            PowerConsumption);
    }

    public WiFiAdapterPciExpressVersion4 SetWifiName(string name)
    {
        WiFiAdapterPciExpressVersion4 wifiClone = Clone();

        wifiClone.Name = name;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion4 SetWifiVersion(int version)
    {
        WiFiAdapterPciExpressVersion4 wifiClone = Clone();

        wifiClone.WifiStandardVersion = version;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion4 SetWifiHasBluetooth(bool hasBluetooth)
    {
        WiFiAdapterPciExpressVersion4 wifiClone = Clone();

        wifiClone.HasBluetooth = hasBluetooth;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion4 SetWifiPowerConsumption(int powerConsumption)
    {
        WiFiAdapterPciExpressVersion4 wifiClone = Clone();

        wifiClone.PowerConsumption = powerConsumption;

        return wifiClone;
    }
}