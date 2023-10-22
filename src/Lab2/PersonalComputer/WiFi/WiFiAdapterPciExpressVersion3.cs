namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public class WiFiAdapterPciExpressVersion3 : IWiFi
{
    public WiFiAdapterPciExpressVersion3(string? name, int wifiStandardVersion, bool hasBluetooth, int powerConsumption)
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

    public WiFiAdapterPciExpressVersion3 Clone()
    {
        return new WiFiAdapterPciExpressVersion3(
            Name,
            WifiStandardVersion,
            HasBluetooth,
            PowerConsumption);
    }

    public WiFiAdapterPciExpressVersion3 SetWifiName(string name)
    {
        WiFiAdapterPciExpressVersion3 wifiClone = Clone();

        wifiClone.Name = name;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion3 SetWifiVersion(int version)
    {
        WiFiAdapterPciExpressVersion3 wifiClone = Clone();

        wifiClone.WifiStandardVersion = version;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion3 SetWifiHasBluetooth(bool hasBluetooth)
    {
        WiFiAdapterPciExpressVersion3 wifiClone = Clone();

        wifiClone.HasBluetooth = hasBluetooth;

        return wifiClone;
    }

    public WiFiAdapterPciExpressVersion3 SetWifiPowerConsumption(int powerConsumption)
    {
        WiFiAdapterPciExpressVersion3 wifiClone = Clone();

        wifiClone.PowerConsumption = powerConsumption;

        return wifiClone;
    }
}