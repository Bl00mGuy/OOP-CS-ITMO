using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.WiFi;

public interface IWiFi : IComponent
{
    int WifiStandardVersion { get; }
    bool HasBluetooth { get; }
    int PowerConsumption { get; }
}